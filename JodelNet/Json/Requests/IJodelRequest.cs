using System.Collections.Generic;
using System.Threading.Tasks;
using JodelNet.Extensions;
using JodelNet.Json.RequestModels;

namespace JodelNet.Json.Requests
{
    public interface IJodelRequest<TResponse>
    {
        Task<TResponse> PerformActionAsync(List<Pair<string, string>> parameters = null, JodelRequest payload = null, string urlExtension = null);
    }
}
