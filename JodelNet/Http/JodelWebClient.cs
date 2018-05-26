using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace JodelNet.Http
{
    //https://github.com/ioncodes/JodelAPI/blob/master/JodelAPI/JodelAPI/Internal/JodelWebClient.cs
    public class JodelWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address) as HttpWebRequest;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            request.ServicePoint.Expect100Continue = false;
            return request;
        }

        public static JodelWebClient Create(DateTime timestamp, string stringifiedPayload = "", string accesstoken = "", HttpMethod method = null)
        {
            var wc = new JodelWebClient {Encoding = Encoding.UTF8};
            wc.Headers.Clear();

            wc.Headers.Add(Constants.WebHeaders);

            var keyByte = Encoding.UTF8.GetBytes(Constants.HMAC_SECRET);
            var hmacsha1 = new HMACSHA1(keyByte);
            hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(stringifiedPayload));

            wc.Headers.Add("X-Timestamp", $"{timestamp:s}Z");
            wc.Headers.Add("X-Authorization", "HMAC " + hmacsha1.Hash.Aggregate(string.Empty, (current, t) => current + t.ToString("X2")));

            if (!string.IsNullOrEmpty(accesstoken))
            {
                wc.Headers.Add("Authorization", "Bearer " + accesstoken);
            }

            if (method != HttpMethod.Get)
                wc.Headers.Add(Constants.PostWebHeaders);

            return wc;
        }
    }
}
