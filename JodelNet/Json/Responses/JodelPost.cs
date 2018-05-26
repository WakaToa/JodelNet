using System;
using System.Collections.Generic;
using JodelNet.Json.RequestModels;
using Newtonsoft.Json;

namespace JodelNet.Json.Responses
{
    public class JodelPost
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("pin_count")]
        public long PinCount { get; set; }

        [JsonProperty("image_approved")]
        public bool ImageApproved { get; set; }

        [JsonProperty("child_count")]
        public long ChildCount { get; set; }

        [JsonProperty("replier")]
        public long Replier { get; set; }

        [JsonProperty("post_id")]
        public string PostId { get; set; }

        [JsonProperty("discovered_by")]
        public long DiscoveredBy { get; set; }

        [JsonProperty("vote_count")]
        public long VoteCount { get; set; }

        [JsonProperty("got_thanks")]
        public bool GotThanks { get; set; }

        [JsonProperty("share_count")]
        public long ShareCount { get; set; }

        [JsonProperty("user_handle")]
        public string UserHandle { get; set; }

        [JsonProperty("view_count")]
        public long ViewCount { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("post_own")]
        public string PostOwn { get; set; }

        [JsonProperty("distance")]
        public long Distance { get; set; }

        [JsonProperty("location")]
        public LocationJson Location { get; set; }

        [JsonProperty("children")]
        public List<object> Children { get; set; }

        [JsonProperty("from_home", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FromHome { get; set; }

        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }

        [JsonProperty("image_headers", NullValueHandling = NullValueHandling.Ignore)]
        public ImageHeader ImageHeaders { get; set; }

        [JsonProperty("thumbnail_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ThumbnailUrl { get; set; }

        public class ImageHeader
        {
            [JsonProperty("Host")]
            public string Host { get; set; }

            [JsonProperty("X-Amz-Date")]
            public string XAmzDate { get; set; }

            [JsonProperty("x-amz-content-sha256")]
            public string XAmzContentSha256 { get; set; }

            [JsonProperty("Authorization")]
            public string Authorization { get; set; }
        }
    }
}
