using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JodelNet.Json.RequestModels
{
    public class CreatePostJson : JodelRequest
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("location")]
        public LocationJson Location { get; set; }

        [JsonProperty("ancestor")]
        public string Ancestor { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("image")]
        public string B64Image { get; set; }

        [JsonProperty("to_home")]
        public bool ToHome { get; set; }
    }
}
