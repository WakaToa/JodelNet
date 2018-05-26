namespace JodelNet.Json.Models
{
    public class VerifyPushTokenJson : JodelRequest
    {
        public string server_time { get; set; }
        public string verification_code { get; set; }
    }
}
