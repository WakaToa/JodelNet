using System.Collections.Generic;

namespace JodelNet.Json.Responses
{
    public class GetRecommendedChannelsResponse : JodelResponse
    {
        public List<ChannelData> recommended { get; set; }
        public List<ChannelData> local { get; set; }
        public List<ChannelData> country { get; set; }
        public List<ChannelData> @default { get; set; }
        public string mainChannel { get; set; }

        public class ChannelData
        {
            public string channel { get; set; }
            public int followers { get; set; }
            public string image_url { get; set; }
            public int country_followers { get; set; }
        }
    }
}
