using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JodelNet.Extensions;
using JodelNet.Json.Models;

namespace JodelNet.Json.Requests
{
    public class GetPostDetailsRequest : JodelRequestBase, IJodelRequest<string>
    {
        public GetPostDetailsRequest(JodelUser user, HttpMethod method, string url, string version = "v2", string postData = "", bool authorize = true) : base(user, method, url, version, postData, authorize)
        {
        }

        public async Task<string> PerformActionAsync(List<Pair<string, string>> parameters = null, JodelRequest payload = null, string postId = null)
        {
            var plainResponse = await ExecuteRequestAsync(parameters, payload, postId);

            return plainResponse;
        }
    }
}
