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
            {"Accept-Encoding", "gzip"},
            {"User-Agent", "Jodel/" + VERSION + " Dalvik/2.1.0 (Linux; U; Android 6.0.1; E6653 Build/32.2.A.0.305)"},
            {"X-Client-Type", "android_" + VERSION},
            {"X-Api-Version", "0.2"}
        };

        public static WebHeaderCollection PostWebHeaders = new WebHeaderCollection()
        {
            {"Content-Type", "application/json; charset=UTF-8"}
        };
    }
}
