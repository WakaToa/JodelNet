using System.Collections.Generic;
using Newtonsoft.Json;

namespace JodelNet.Json.Responses
{
    public class CreateAccountResponse : JodelResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("expiration_date")]
        public long ExpirationDate { get; set; }

        [JsonProperty("distinct_id")]
        public string DistinctId { get; set; }

        [JsonProperty("returning")]
        public bool Returning { get; set; }

        [JsonProperty("experiments")]
        public List<Experiment> Experiments { get; set; }

        public class Experiment
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("group")]
            public string Group { get; set; }

            [JsonProperty("features")]
            public List<string> Features { get; set; }
        }
    }
}
