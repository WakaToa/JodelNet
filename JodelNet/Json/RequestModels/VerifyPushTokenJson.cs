using Newtonsoft.Json;

namespace JodelNet.Json.RequestModels
{
    public class VerifyPushTokenJson : JodelRequest
    {
        [JsonProperty("server_time")]
        public string ServerTime { get; set; }

        [JsonProperty("verification_code")]
        public string VerificationCode { get; set; }
    }
}
