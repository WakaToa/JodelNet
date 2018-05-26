using System.Collections.Generic;
using Newtonsoft.Json;

namespace JodelNet.Json.Responses
{
    public class GetPostsResponse : JodelResponse
    {
        [JsonProperty("max")]
        public long Max { get; set; }

        [JsonProperty("posts")]
        public List<JodelPost> Posts { get; set; }
    }
}
