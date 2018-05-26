using Newtonsoft.Json;

namespace JodelNet.Json.RequestModels
{
    public class RefreshAccessTokenJson : JodelRequest
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("distinct_id")]
        public string DistinctId { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
