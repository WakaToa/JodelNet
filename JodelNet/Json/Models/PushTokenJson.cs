namespace JodelNet.Json.Models
{
    public class PushTokenJson : JodelRequest
    {
        public string client_id { get; set; }
        public string push_token { get; set; }
    }
}
