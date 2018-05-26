using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JodelNet.Json.Responses
{
    public class VotePostResponse : JodelResponse
    {
        [JsonProperty("post")]
        public JodelPost Post { get; set; }

        [JsonProperty("vote_count")]
        public long VoteCount { get; set; }
    }
}
