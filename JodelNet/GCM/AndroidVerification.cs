using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JodelNet.GCM.Proto;
using JodelNet.GCM.Stream;

namespace JodelNet.GCM
{
    //https://github.com/microg/android_packages_apps_GmsCore/blob/93c3cbb31be6c8ffae81c18e551cb00c74aaaaf4/play-services-core/src/main/java/org/microg/gms/gcm/mcs/McsService.java
    //https://github.com/nborrmann/gcmreverse

    public class AndroidVerification
    {
        public static string GetRandomDeviceUid()
        {
            var rnd = Guid.NewGuid().ToString();

            using (var hash = SHA256.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(rnd)).Select(item => item.ToString("x2")));
            }
        }

        //todo: not 100% async yet
        public static async Task<AndroidVerificationResult> VerifyAccountAsync(JodelUser jodelUser)
        {
            var checkinRequestProto = new CheckinRequest
            {
                checkin = new CheckinRequest.Checkin {build = new CheckinRequest.Checkin.Build {sdkVersion = 18}},
                version = 3,
                fragment = 0
            };

            var data = SerializeToByteArray(checkinRequestProto);

            var webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/x-protobuffer");
            webClient.Headers.Add("Accept-Encoding", "deflate");
            webClient.Headers.Add("User-Agent", "Android-Checkin/2.0 (vbox86p JLS36G); deflate");
            var checkinResponseString = await webClient.UploadDataTaskAsync("https://android.clients.google.com/checkin", data);

            CheckinResponse checkinResponseProto;

            try
            {
                checkinResponseProto = ProtoBuf.Serializer.Deserialize<CheckinResponse>(new MemoryStream(checkinResponseString));
            }
            catch (Exception)
            {
                return new AndroidVerificationResult(false, "Couldn't deserialize CheckinProtoResponse.");
            }

            var registerPostData = "app=com.tellm.android.app&app_ver=1001800&cert=a4a8d4d7b09736a0f65596a868cc6fd620920fb0&device=" + checkinResponseProto.androidId + "&sender=425112442765&X-appid=" + Guid.NewGuid().ToString("n").Substring(0, 11) + "&X-scope=GCM";

            webClient.Headers.Clear();
            webClient.Headers.Add("Authorization", "AidLogin " + checkinResponseProto.androidId + ":" + checkinResponseProto.securityToken);
            webClient.Headers.Add("Accept", "*/*");
            webClient.Headers.Add("Accept-Encoding", "deflate");
            webClient.Headers.Add("User-Agent", "Android-Checkin/2.0 (vbox86p JLS36G); deflate");
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            var registerTokenResponseString = await webClient.UploadStringTaskAsync("https://android.clients.google.com/c2dm/register3", registerPostData);

            if (!registerTokenResponseString.Contains("token"))
            {
                return new AndroidVerificationResult(false, "Couldn't register c2dm token.");
            }
            var registerToken = registerTokenResponseString.Replace("token=", "");

            var tokenPushed = await jodelUser.PushTokenAsync(registerToken);
            if (!tokenPushed)
            {
                return new AndroidVerificationResult(false, "Couldn't push c2dm token.");
            }
            var loginRequestProto = new LoginRequest
            {
                auth_service = 2,
                auth_token = checkinResponseProto.securityToken.ToString(),
                id = "android-11",
                domain = "mcs.android.com",
                device_id = "android-" + checkinResponseProto.androidId.ToString("X"),
                resource = checkinResponseProto.androidId.ToString(),
                user = checkinResponseProto.androidId.ToString(),
                use_rmq2 = true,
                account_id = (long)checkinResponseProto.androidId
            };


            var loginRequestBytes = SerializeToByteArray(loginRequestProto);

            var client = new TcpClient("mtalk.google.com", 5228);
            var sslStream = new SslStream(client.GetStream(), false, (sender, certificate, chain, errors) => true, null);
            sslStream.AuthenticateAsClient("mtalk.google.com");

            var inputStream = new McsInputStream(sslStream);
            var outputStream = new McsOutputStream(sslStream);
            outputStream.WriteProtoMessage((int)MCSToken.MCS_LOGIN_REQUEST_TAG, loginRequestBytes);


            //not async yet
            //no heartbeat implemented
            var verificationData = "";
            while (true)
            {
                var read = inputStream.ReadProtoMessage();

                if (read.McsTag == MCSToken.MCS_LOGIN_RESPONSE_TAG)
                {
                    var loginResponse = ProtoBuf.Serializer.Deserialize<LoginResponse>(new MemoryStream(read.McsData));
                    if (loginResponse.error != null)
                    {
                        var error = Encoding.Default.GetString(loginResponse.error.extension.data);
                        client.Close();
                        return new AndroidVerificationResult(false, "MCSError: " + error);
                    }
                }
                if (read.McsTag == MCSToken.MCS_DATA_MESSAGE_STANZA_TAG)
                {
                    var stanzda = ProtoBuf.Serializer.Deserialize<DataMessageStanza>(new MemoryStream(read.McsData));

                    if (stanzda.app_data.Count(x => x.key == "message_type_id" && x.value == "16") == 1 && stanzda.category == "com.tellm.android.app")
                    {
                        verificationData = stanzda.app_data.FirstOrDefault(x => x.key == "payload")?.value ?? "";
                        client.Close();
                        break;
                    }
                }
                if (read.McsTag == MCSToken.MCS_CLOSE_TAG)
                {
                    client.Close();
                    return new AndroidVerificationResult(false, "MCS server closed connection before retrieving verification data.");
                }

            }
            if (!verificationData.Contains("verification_code"))
            {
                return new AndroidVerificationResult(false, "MCS server didn't contain verification_code field.");
            }
            var serverTime = Regex.Match(verificationData, "\"server_time\":(.*?),").Groups[1].Value;
            var verificationToken = Regex.Match(verificationData, "\"verification_code\":\"(.*?)\"").Groups[1].Value;
            var verifiedPushToken =  await jodelUser.VerifyPushTokenAsync(serverTime, verificationToken);
            return !verifiedPushToken ? new AndroidVerificationResult(false, "Couldn't verify pushed c2dm token.") : new AndroidVerificationResult(true, "");
        }

        private static byte[] SerializeToByteArray<T>(T instance)
        {
            byte[] data;
            using (var ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, instance);

                data = ms.ToArray();
            }

            return data;
        }
    }
}
