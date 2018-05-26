using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JodelNet.Json.Responses
{
    public class GetUserStatsResponse : JodelResponse
    {
        [JsonProperty("karma")]
        public long Karma { get; set; }

        [JsonProperty("thanks")]
        public long Thanks { get; set; }
    }
}
