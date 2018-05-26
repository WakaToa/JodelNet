using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JodelNet.Json.Responses
{
    public class GetPostsCombinedResponse : JodelResponse
    {
        [JsonProperty("max")]
        public long Max { get; set; }

        [JsonProperty("recent")]
        public List<JodelPost> Recent { get; set; }

        [JsonProperty("replied")]
        public List<JodelPost> Replied { get; set; }

        [JsonProperty("voted")]
        public List<JodelPost> Voted { get; set; }
    }
}
