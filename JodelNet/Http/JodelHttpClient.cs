using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JodelNet.Http
{
    public class JodelHttpClient
    {
        private readonly HttpClient _httpClient;

        public HttpClientHandler ClientHandler { get; set; }
        public JodelHttpClient()
        {
            ClientHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip,
                AllowAutoRedirect = true,
                ClientCertificateOptions = ClientCertificateOption.Automatic
            };
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.DefaultConnectionLimit = int.MaxValue;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.UseNagleAlgorithm = false;
            ServicePointManager.MaxServicePoints = int.MaxValue;
            ServicePointManager.SetTcpKeepAlive(true, 6000000, 100000);

            _httpClient = new HttpClient(ClientHandler);
            AddCommonHeaders();
        }

        private void SetExpectContinueHeaderToFalse()
        {
            _httpClient.DefaultRequestHeaders.ExpectContinue = false;
        }

        public void ClearRequestHeaders()
        {
            _httpClient.DefaultRequestHeaders.Clear();
        }

        public void AddConnectionKeepAliveHeader()
        {
            _httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
        }

        public void AddRequestHeader(string name, string value)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(name, value);
            }
            catch
            {

            }

        }

        public void RemoveRequestHeader(string name)
        {
            _httpClient.DefaultRequestHeaders.Remove(name);
        }

        public async Task<HttpResponseMessage> SendAsync(string url, HttpMethod method, string data)
        {
            using (var req = new HttpRequestMessage(method, url))
            {
                if (!string.IsNullOrEmpty(data))
                {
                    req.Content = new StringContent(data, Encoding.UTF8, "application/json");
                }

                return await _httpClient.SendAsync(req);
            }
        }

        public void AddCommonHeaders()
        {
            foreach (var webHeader in Constants.WebHeaders.AllKeys)
            {
                AddRequestHeader(webHeader,Constants.WebHeaders[webHeader]);
            }

            AddConnectionKeepAliveHeader();
            SetExpectContinueHeaderToFalse();
        }

        public void AddPostsHeaders()
        {
            foreach (var webHeader in Constants.PostWebHeaders.AllKeys)
            {
                AddRequestHeader(webHeader, Constants.PostWebHeaders[webHeader]);
            }
        }


        public static JodelHttpClient Create(DateTime timestamp, string stringifiedPayload = "", string accesstoken = "", HttpMethod method = null)
        {
            var httpClient = new JodelHttpClient();

            var keyByte = Encoding.UTF8.GetBytes(Constants.HMAC_SECRET);
            var hmacsha1 = new HMACSHA1(keyByte);
            hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(stringifiedPayload));

            httpClient.AddRequestHeader("X-Timestamp", $"{timestamp:s}Z");
            httpClient.AddRequestHeader("X-Authorization", "HMAC " + hmacsha1.Hash.Aggregate(string.Empty, (current, t) => current + t.ToString("X2")));

            if (!string.IsNullOrEmpty(accesstoken))
            {
                httpClient.AddRequestHeader("Authorization", "Bearer " + accesstoken);
            }

            if (method != HttpMethod.Get)
            {
                httpClient.AddPostsHeaders();
            }

            return httpClient;
        }
    }
}
