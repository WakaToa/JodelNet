using System;
using System.Collections.Generic;
using JodelNet.Json.Models;

namespace JodelNet.Json.Responses
{
    public class ImageHeaders
    {
        public string Host { get; set; }
        public string Authorization { get; set; }
    }

    public class Post
    {
        public string post_id { get; set; }
        public string created_at { get; set; }
        public string AgeFormatted
        {
            get
            {
                var created = DateTime.Parse(created_at).ToUniversalTime();
                var old = (DateTime.UtcNow - created);
                var str = "";
                if (old.Days > 0)
                {
                    str += old.Days + "d ";
                }
                if (old.Hours > 0)
                {
                    str += old.Hours + "h ";
                }
                if (old.Minutes > 0)
                {
                    str += old.Minutes + "m ";
                }
                if (old.Seconds > 0)
                {
                    str += old.Seconds + "s ";
                }
                return str;
            }
        }
        public string message { get; set; }
        public int discovered_by { get; set; }
        public string updated_at { get; set; }
        public string post_own { get; set; }
        public int discovered { get; set; }
        public int distance { get; set; }
        public int vote_count { get; set; }
        public string color { get; set; }

        public string ColorString
        {
            get
            {
                switch (color)
                {
                    case "DD5F5F":
                        return "red";
                    case "FFBA00":
                        return "yellow";
                    case "8ABDB0":
                        return "blue";
                    case "06A3CB":
                        return "light-blue";
                    case "9EC41C":
                        return "green";
                    case "FF9908":
                        return "orange";
                    default:
                        return "white";
                }
            }
        }
        public Location location { get; set; }
        public List<object> tags { get; set; }
        public string user_handle { get; set; }
        public string image_url { get; set; }
        public ImageHeaders image_headers { get; set; }
        public string thumbnail_url { get; set; }
        public bool IsPicture => !string.IsNullOrEmpty(thumbnail_url);
        public string voted { get; set; }
        public int? child_count { get; set; }
        public List<Post> children { get; set; }
        public bool got_thanks { get; set; }
        public bool notifications_enabled { get; set; }
        public int pin_count { get; set; }
        public string channel { get; set; }
        public string ChannelString => !string.IsNullOrEmpty(channel) ? "@" + channel : "";
    }

    public class PostJodels
    {
        public List<Post> posts { get; set; }
        public int max { get; set; }
    }
}
