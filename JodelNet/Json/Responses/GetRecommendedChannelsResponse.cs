using System.Collections.Generic;
using Newtonsoft.Json;

namespace JodelNet.Json.Responses
{
    public class GetRecommendedChannelsResponse : JodelResponse
    {
        [JsonProperty("recommended")]
        public List<ChannelData> Recommended { get; set; }

        [JsonProperty("local")]
        public List<ChannelData> Local { get; set; }

        [JsonProperty("country")]
        public List<ChannelData> Country { get; set; }

        [JsonProperty("default")]
        public List<DefaultChannel> Default { get; set; }

        [JsonProperty("mainChannel")]
        public string MainChannel { get; set; }

        public class ChannelData
        {
            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("image_url")]
            public string ImageUrl { get; set; }

            [JsonProperty("followers")]
            public long Followers { get; set; }

            [JsonProperty("country_followers")]
            public long CountryFollowers { get; set; }
        }

        public class DefaultChannel
        {
            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("emoticon")]
            public string Emoticon { get; set; }

            [JsonProperty("description_key", NullValueHandling = NullValueHandling.Ignore)]
            public string DescriptionKey { get; set; }
        }
    }
}
