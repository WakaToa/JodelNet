using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JodelNet.Extensions;
using JodelNet.Json.Models;
using JodelNet.Json.Responses;

namespace JodelNet.Json.Requests
{
    class GetRecommendedChannelsRequest : JodelRequestBase, IJodelRequest<GetRecommendedChannelsResponse>
    {
        public async Task<GetRecommendedChannelsResponse> PerformActionAsync(List<Pair<string, string>> parameters = null, JodelRequest payload = null, string postId = null)
        {
            var plainResponse = await ExecuteRequestAsync(parameters, payload, postId);

            return Deserialize<GetRecommendedChannelsResponse>(plainResponse);
        }

        public GetRecommendedChannelsRequest(JodelUser user, HttpMethod method, string url, string version = "v3", string postData = "", bool authorize = true) : base(user, method, url, version, postData, authorize)
        {
        }
    }
}
