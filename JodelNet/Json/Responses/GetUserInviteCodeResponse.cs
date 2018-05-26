using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JodelNet.Json.Responses
{
    public class GetUserInviteCodeResponse : JodelResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
