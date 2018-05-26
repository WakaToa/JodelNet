using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JodelNet.Json.Responses
{
    public class GetSharePostUrlResponse : JodelResponse
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("share_count")]
        public long ShareCount { get; set; }

        [JsonProperty("shareCountUpdated")]
        public bool ShareCountUpdated { get; set; }
    }
}
