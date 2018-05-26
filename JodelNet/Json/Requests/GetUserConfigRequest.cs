﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JodelNet.Extensions;
using JodelNet.Json.Models;
using JodelNet.Json.Responses;

namespace JodelNet.Json.Requests
{
    public class GetUserConfigRequest : JodelRequestBase, IJodelRequest<GetUserConfigResponse>
    {
        public GetUserConfigRequest(JodelUser user, HttpMethod method, string url, string version = "v2", string postData = "", bool authorize = true) : base(user, method, url, version, postData, authorize)
        {
        }

        public async Task<GetUserConfigResponse> PerformActionAsync(List<Pair<string, string>> parameters = null, JodelRequest payload = null, string postId = null)
        {
            var plainResponse = await ExecuteRequestAsync(parameters, payload, postId);

            return Deserialize<GetUserConfigResponse>(plainResponse);
        }
    }
}
