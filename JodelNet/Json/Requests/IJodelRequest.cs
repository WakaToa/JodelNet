using System.Collections.Generic;
using System.Threading.Tasks;
using JodelNet.Extensions;
using JodelNet.Json.Models;

namespace JodelNet.Json.Requests
{
    public interface IJodelRequest<TResponse>
    {
        Task<TResponse> PerformActionAsync(List<Pair<string, string>> parameters = null, JodelRequest payload = null, string postId = null);
    }
}
