namespace JodelNet.Json.Models
{
    public class SetLocationJson : JodelRequest
    {
        public Location location { get; set; } = new Location();
    }
}
