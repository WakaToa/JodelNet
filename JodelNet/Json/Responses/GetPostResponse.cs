using System.Collections.Generic;

namespace JodelNet.Json.Responses
{
    public class GetPostResponse : JodelResponse
    {
        public List<Post> posts { get; set; }
        public int max { get; set; }
    }
}
