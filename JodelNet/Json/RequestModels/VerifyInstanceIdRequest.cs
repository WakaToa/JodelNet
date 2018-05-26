using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JodelNet.Json.RequestModels
{
    public class VerifyInstanceIdRequest : JodelRequest
    {
        [JsonProperty("iid")]
        public string InstanceId { get; set; }
    }
}
