﻿namespace JodelNet.Json.Responses
{
    public class CreateAccountResponse : JodelResponse
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public int expiration_date { get; set; }
        public string distinct_id { get; set; }
        public bool returning { get; set; }
    }
}
