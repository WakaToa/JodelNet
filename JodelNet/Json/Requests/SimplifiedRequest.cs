using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JodelNet.Extensions;
using JodelNet.Json.RequestModels;
using JodelNet.Json.Responses;

namespace JodelNet.Json.Requests
{
    public class SimplifiedRequest<T>: JodelRequestBase, IJodelRequest<T> where T : JodelResponse, new()
    {
        public async Task<T> PerformActionAsync(List<Pair<string, string>> parameters = null, JodelRequest payload = null, string postId = null)
        {
            var plainResponse = await ExecuteRequestAsync(parameters, payload, postId);

            return await Deserialize<T>(plainResponse);
        }

        public SimplifiedRequest(JodelUser user, HttpMethod method, string url, string version = "v2", string postData = "") : base(user, method, url, version, postData)
        {
        }
    }
}
