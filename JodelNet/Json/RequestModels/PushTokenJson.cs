using Newtonsoft.Json;

namespace JodelNet.Json.RequestModels
{
    public class PushTokenJson : JodelRequest
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("push_token")]
        public string PushToken { get; set; }
    }
}
