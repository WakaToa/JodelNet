using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JodelNet.Json.Responses
{
    public class VerifyInstanceIdResponse : JodelResponse
    {
        [JsonProperty("verified")]
        public bool Verified { get; set; }
    }
}
