namespace JodelNet.Json.Models
{
    public class RefreshAccessTokenJson : JodelRequest
    {
        public string client_id { get; set; }
        public string distinct_id { get; set; }
        public string refresh_token { get; set; }
    }
}
