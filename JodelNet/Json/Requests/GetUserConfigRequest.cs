using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JodelNet.Extensions;
using JodelNet.Json.RequestModels;
using JodelNet.Json.Responses;

namespace JodelNet.Json.Requests
{
    public class GetUserConfigRequest : JodelRequestBase, IJodelRequest<GetUserConfigResponse>
    {
        public GetUserConfigRequest(JodelUser user, HttpMethod method, string url, string version = "v2", string postData = "") : base(user, method, url, version, postData)
        {
        }

        public async Task<GetUserConfigResponse> PerformActionAsync(List<Pair<string, string>> parameters = null, JodelRequest payload = null, string postId = null)
        {
            var plainResponse = await ExecuteRequestAsync(parameters, payload, postId);

            return await Deserialize<GetUserConfigResponse>(plainResponse);
        }
    }
}
