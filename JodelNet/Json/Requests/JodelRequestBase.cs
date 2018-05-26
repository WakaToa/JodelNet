using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JodelNet.Extensions;
using JodelNet.Http;
using JodelNet.Json.RequestModels;
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

        protected JodelRequestBase(JodelUser user, HttpMethod method, string url, string version = "v2", string postData = "")
        {
            User = user;
            Method = method;
            Url = url;
            Version = version;
            PostData = postData;
        }

        public async Task<HttpResponseMessage> ExecuteRequestAsync(List<Pair<string, string>> parameters = null, JodelRequest payload = null, string urlExtension = null)
        {
            var payloadString = payload != null
                ? JsonConvert.SerializeObject(payload, Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    })
                : null;
            var dt = DateTime.Now;
            var urlParam = Url;

            if (!string.IsNullOrWhiteSpace(urlExtension)) urlParam += urlExtension;
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
                var client = JodelHttpClient.Create(dt, stringifiedPayload, User.AccessToken, Method);
                return await client.SendAsync(stringifiedUrl, Method, payloadString);
            }
            catch (WebException e)
            {
                var s = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
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

        protected static async Task<T> Deserialize<T>(HttpResponseMessage message) where T : JodelResponse, new()
        {
            switch ((int)message.StatusCode)
            {
                case 401:
                    return new T(){Code = JodelResponseCodes.UNAUTHORIZED};
                case 402:
                    return new T() { Code = JodelResponseCodes.ACTION_NOT_ALLOWED };
                case 403:
                    return new T() { Code = JodelResponseCodes.ACCESS_DENIED };
                case 429:
                    return new T() { Code = JodelResponseCodes.TOO_MANY_REQUESTS };
                case 477:
                    return new T() { Code = JodelResponseCodes.SIGNED_REQUEST_EXPECTED };
                case 478:
                    return new T() { Code = JodelResponseCodes.ACCOUNT_NOT_VERIFIED };
                case 502:
                    return new T() { Code = JodelResponseCodes.BAD_GATEWAY };
            }
            var messageContent = await message.Content.ReadAsStringAsync().ConfigureAwait(false);

            return Deserialize<T>(messageContent);
        }
    }
}
