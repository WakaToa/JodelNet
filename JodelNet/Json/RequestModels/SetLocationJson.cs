using Newtonsoft.Json;

namespace JodelNet.Json.RequestModels
{
    public class SetLocationJson : JodelRequest
    {
        [JsonProperty("location")]
        public LocationJson Location { get; set; } = new LocationJson();
    }
}
