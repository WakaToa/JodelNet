using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JodelNet.Extensions;
using JodelNet.Json.Models;

namespace JodelNet.Json.Requests
{
    public class VerifyPushTokenRequest : JodelRequestBase, IJodelRequest<bool>
    {
        public async Task<bool> PerformActionAsync(List<Pair<string, string>> parameters = null, JodelRequest payload = null, string postId = null)
        {
            var plainResponse = await ExecuteRequestAsync(parameters, payload, postId);

            return plainResponse == "";
        }

        public VerifyPushTokenRequest(JodelUser user, HttpMethod method, string url, string version = "v2", string postData = "", bool authorize = true) : base(user, method, url, version, postData, authorize)
        {
        }
    }
}
