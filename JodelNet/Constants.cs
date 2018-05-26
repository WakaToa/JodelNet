using System.Collections.Generic;
using System.Net;

namespace JodelNet
{
    public class Constants
    {
        //Constants
        public const string BASE_URL = "api.go-tellm.com";
        public const string API_URL = BASE_URL + "/api";
        public const string CLIENT_ID = "81e8a76e-1e02-4d17-9ba0-8a7020261b26";
        public const string HMAC_SECRET = "wBcwgMVNszFbizucRWRUldnsvHKBZOJAKFSvOStj";
        public const string VERSION = "4.88.1";

        public static WebHeaderCollection WebHeaders = new WebHeaderCollection()
        {
            {"Accept", "*/*"},
            {"Accept-Encoding", "gzip"},
            {"User-Agent", "Jodel/" + VERSION + " Dalvik/2.1.0 (Linux; U; Android 6.0.1; E6653 Build/32.2.A.0.305)"},
            {"X-Client-Type", "android_" + VERSION},
            {"X-Api-Version", "0.2"}
        };

        public static WebHeaderCollection PostWebHeaders = new WebHeaderCollection()
        {
            {"Content-Type", "application/json; charset=UTF-8"}
        };

        public enum PostColor
        {
            Orange = 0xFF9908,
            Yellow = 0xFFBA00,
            Red = 0xDD5F5F,
            Blue = 0x06A3CB,
            Bluegreyish = 0x8ABDB0,
            Green = 0x9EC41C,
            Random
        }

        public static Dictionary<PostColor, string> Colors = new Dictionary<PostColor, string>
        {
            { PostColor.Red, "DD5F5F" },
            { PostColor.Orange, "FF9908" },
            { PostColor.Yellow, "FFBA00" },
            { PostColor.Blue, "DD5F5F" },
            { PostColor.Bluegreyish, "8ABDB0" },
            { PostColor.Green, "9EC41C" },
            { PostColor.Random, "FFFFFF" }
        };

        public static string GetColor(PostColor color) => Colors[color];
    }
}
