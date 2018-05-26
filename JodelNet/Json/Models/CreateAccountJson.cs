namespace JodelNet.Json.Models
{
    public class CreateAccountJson : JodelRequest
    {
        public string device_uid { get; set; }
        public Location location { get; set; }
        public string client_id { get; set; }
    }
}
