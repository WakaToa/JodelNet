using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JodelNet.Json.Responses
{
    public class PinPostResponse : JodelResponse
    {
        [JsonProperty("pin_count")]
        public long PinCount { get; set; }
    }
}
