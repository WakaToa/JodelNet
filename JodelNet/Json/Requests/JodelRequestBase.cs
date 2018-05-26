using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JodelNet.Extensions;
using JodelNet.Http;
using JodelNet.Json.Models;
using JodelNet.Json.Responses;
using Newtonsoft.Json;

namespace JodelNet.Json.Requests
{
    public abstract class JodelRequestBase
    {
        public JodelUser User { get; set; }

        public HttpMethod Method { get; }

        public string Url { get; }

        public string Version { get; }

        public string PostData { get; }

        public bool Authorize { get; }

        protected JodelRequestBase(JodelUser user, HttpMethod method, string url, string version = "v2", string postData = "", bool authorize = true)
        {
            User = user;
            Method = method;
            Url = url;
            Version = version;
            PostData = postData;
            Authorize = authorize;
        }

        public async Task<string> ExecuteRequestAsync(List<Pair<string, string>> parameters = null, JodelRequest payload = null, string postId = null)
        {
            string plainJson = null;
            string payloadString = payload != null
                ? JsonConvert.SerializeObject(payload, Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    })
                : null;
            var dt = DateTime.Now;
            var urlParam = Url;

            if (!string.IsNullOrWhiteSpace(postId)) urlParam += postId;
            if (!string.IsNullOrWhiteSpace(PostData)) urlParam += PostData;

            if (parameters != null)
            {
                urlParam += "?" + string.Join("&", parameters.Select(p => $"{p.First}={p.Second}"));
            }

            var stringifiedUrl = "https://" + Constants.BASE_URL + "/api/" + Version + urlParam;

            var stringifiedPayload = Method.Method + "%" + Constants.BASE_URL + "%443%/api/" + Version + urlParam;
            stringifiedPayload += "%" + User.AccessToken;
            stringifiedPayload += "%" + $"{dt:s}Z" + "%%" + payloadString;

            try
            {
                using (var client = JodelWebClient.Create(dt, stringifiedPayload, User.AccessToken, Method))
                {
                    if (Method == HttpMethod.Get)
                    {
                        plainJson = await client.DownloadStringTaskAsync(stringifiedUrl);
                    }
                    else
                    {
                        plainJson = await client.UploadStringTaskAsync(stringifiedUrl, Method.Method, payloadString ?? string.Empty);
                    }
                }

                return plainJson;
            }
            catch (WebException e)
            {
                var s = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                return s;
            }

        }

        protected static T Deserialize<T>(string messageContent) where T : JodelResponse, new()
        {
            T deserializedObject = null;

            try
            {
                deserializedObject = JsonConvert.DeserializeObject<T>(messageContent);
            }
            catch (JsonSerializationException)
            {
                try
                {
                    var futError = JsonConvert.DeserializeObject<JodelResponse>(messageContent);
                    deserializedObject = (T)futError;
                }
#pragma warning disable CS0168
                catch (JsonSerializationException e)
                {
                    deserializedObject = new T {Code = JodelResponseCodes.JSON_ERROR};
                }
#pragma warning restore CS0168
            }
            return deserializedObject ?? (new T {Code = JodelResponseCodes.NULL_RESPONSE_ERROR});
        }
    }
}
