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
    public class GetSharePostUrlRequest : JodelRequestBase, IJodelRequest<GetSharePostUrlResponse>
    {
        public async Task<GetSharePostUrlResponse> PerformActionAsync(List<Pair<string, string>> parameters = null, JodelRequest payload = null, string postId = null)
        {
            var plainResponse = await ExecuteRequestAsync(parameters, payload, postId);

            return await Deserialize<GetSharePostUrlResponse>(plainResponse);
        }

        public GetSharePostUrlRequest(JodelUser user, HttpMethod method, string url, string version = "v2", string postData = "") : base(user, method, url, version, postData)
        {
        }
    }
}
