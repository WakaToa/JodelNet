using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JodelNet.Json.RequestModels
{
    public class PostInviteCompleteJson : JodelRequest
    {
        public PostInviteCompleteJson()
        {
            Action = "RegistrationCompleted";
        }
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("post")]
        public string Post { get; set; }

        [JsonProperty("referrer")]
        public string Referrer { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}
