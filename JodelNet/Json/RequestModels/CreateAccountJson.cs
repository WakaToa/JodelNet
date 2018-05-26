using Newtonsoft.Json;

namespace JodelNet.Json.RequestModels
{
    public class CreateAccountJson : JodelRequest
    {
        [JsonProperty("device_uid")]
        public string DeviceUid { get; set; }

        [JsonProperty("location")]
        public LocationJson Location { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }
    }
}
