using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JodelNet.Json.RequestModels
{
    public class FollowChannelsJson : JodelRequest
    {
        [JsonProperty("channels")]
        public List<string> Channels { get; set; }
    }
}
