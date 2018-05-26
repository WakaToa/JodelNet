using System.Collections.Generic;

namespace JodelNet.Json.Responses
{
    public class GetUserConfigResponse : JodelResponse
    {
        public class Experiment
        {
            public string name { get; set; }
            public string group { get; set; }
            public List<string> features { get; set; }
        }

        public class AdsConfig
        {
            public bool consent { get; set; }
        }

        public bool moderator { get; set; }
        public object user_type { get; set; }
        public bool can_change_type { get; set; }
        public object age { get; set; }
        public object birth_date { get; set; }
        public object gender { get; set; }
        public List<Experiment> experiments { get; set; }
        public List<object> special_post_colors { get; set; }
        public List<string> followed_channels { get; set; }
        public List<object> followed_hashtags { get; set; }
        public int channels_follow_limit { get; set; }
        public bool triple_feed_enabled { get; set; }
        public bool home_set { get; set; }
        public string home_name { get; set; }
        public bool home_clear_allowed { get; set; }
        public string location { get; set; }
        public bool user_blocked { get; set; }
        public bool verified { get; set; }
        public bool moderation_notify { get; set; }
        public bool feedInternationalized { get; set; }
        public bool feedInternationalizable { get; set; }
        public bool pending_deletion { get; set; }
        public List<object> user_profiling_types { get; set; }
        public object default_channel { get; set; }
        public object pending_deletion_date { get; set; }
        public AdsConfig ads_config { get; set; }
    }
}
