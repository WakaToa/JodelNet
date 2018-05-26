using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JodelNet.Extensions;
using JodelNet.Json.RequestModels;

namespace JodelNet.Json.Requests
{
    public class SimplifiedBoolRequest : JodelRequestBase, IJodelRequest<bool>
    {
        public SimplifiedBoolRequest(JodelUser user, HttpMethod method, string url, string version = "v2", string postData = "") : base(user, method, url, version, postData)
        {
        }

        public async Task<bool> PerformActionAsync(List<Pair<string, string>> parameters = null, JodelRequest payload = null, string postId = null)
        {
            var plainResponse = await ExecuteRequestAsync(parameters, payload, postId);

            return (int)plainResponse.StatusCode == 204 || (int)plainResponse.StatusCode == 200;
        }
    }
}
