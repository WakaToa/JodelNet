using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JodelNet.Json.RequestModels;
using Newtonsoft.Json;

namespace JodelNet.Json.Responses
{
    public class GetPostDetailsResponse : JodelResponse
    {
        [JsonProperty("details")]
        public Detail Details { get; set; }

        [JsonProperty("replies")]
        public List<Detail> Replies { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("hasPrev")]
        public bool HasPrev { get; set; }

        [JsonProperty("remaining")]
        public long Remaining { get; set; }

        [JsonProperty("shareable")]
        public bool Shareable { get; set; }

        [JsonProperty("readonly")]
        public bool Readonly { get; set; }


        public partial class Detail
        {
            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("created_at")]
            public DateTimeOffset CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public DateTimeOffset UpdatedAt { get; set; }

            [JsonProperty("pin_count")]
            public long PinCount { get; set; }

            [JsonProperty("notifications_enabled", NullValueHandling = NullValueHandling.Ignore)]
            public bool? NotificationsEnabled { get; set; }

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

            [JsonProperty("share_count", NullValueHandling = NullValueHandling.Ignore)]
            public long? ShareCount { get; set; }

            [JsonProperty("view_count", NullValueHandling = NullValueHandling.Ignore)]
            public long? ViewCount { get; set; }

            [JsonProperty("color")]
            public string Color { get; set; }

            [JsonProperty("post_own")]
            public string PostOwn { get; set; }

            [JsonProperty("distance")]
            public long Distance { get; set; }

            [JsonProperty("location")]
            public LocationJson Location { get; set; }

            [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
            public List<object> Children { get; set; }

            [JsonProperty("parent_id", NullValueHandling = NullValueHandling.Ignore)]
            public string ParentId { get; set; }

            [JsonProperty("reply_timestamp", NullValueHandling = NullValueHandling.Ignore)]
            public string ReplyTimestamp { get; set; }

            [JsonProperty("from_home", NullValueHandling = NullValueHandling.Ignore)]
            public bool? FromHome { get; set; }
        }
    }
}
