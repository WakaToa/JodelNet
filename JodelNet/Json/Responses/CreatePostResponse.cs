using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JodelNet.Json.RequestModels;
using Newtonsoft.Json;

namespace JodelNet.Json.Responses
{
    public class CreatePostResponse : JodelResponse
    {
        [JsonProperty("post_id")]
        public string PostId { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        [JsonProperty("parent")]
        public JodelPost Parent { get; set; }
    }
}
