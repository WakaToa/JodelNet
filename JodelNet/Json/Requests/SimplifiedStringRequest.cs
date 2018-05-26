using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JodelNet.Extensions;
using JodelNet.Json.RequestModels;

namespace JodelNet.Json.Requests
{
    //For testing
    public class SimplifiedStringRequest : JodelRequestBase, IJodelRequest<string>
    {
        public SimplifiedStringRequest(JodelUser user, HttpMethod method, string url, string version = "v2", string postData = "") : base(user, method, url, version, postData)
        {
        }

        public async Task<string> PerformActionAsync(List<Pair<string, string>> parameters = null, JodelRequest payload = null, string postId = null)
        {
            var plainResponse = await ExecuteRequestAsync(parameters, payload, postId);

            return await plainResponse.Content.ReadAsStringAsync();
        }
    }
}
