using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using JodelNet.Verification.Proto;

namespace JodelNet.Verification
{
    public class InstanceIdVerification
    {

        public static async Task<VerificationResult> VerifyAccountAsync(JodelUser jodelUser)
        {
            var checkinRequestProto = new CheckinRequest
            {
                checkin = new CheckinRequest.Checkin { build = new CheckinRequest.Checkin.Build { sdkVersion = 18 } },
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
                return new VerificationResult(false, "Couldn't deserialize CheckinProtoResponse.");
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
                return new VerificationResult(false, "Couldn't register c2dm token.");
            }
            var registerToken = registerTokenResponseString.Replace("token=", "");

            var verificationResult = await jodelUser.VerifyInstanceIdAsync(registerToken);
            
            return !verificationResult.Verified ? new VerificationResult(false, "Couldn't verify using c2dm token.") : new VerificationResult(true, "");
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
