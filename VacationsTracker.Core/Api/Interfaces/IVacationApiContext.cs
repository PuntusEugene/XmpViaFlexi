using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace VacationsTracker.Core.Api.Interfaces
{
    public interface IVacationApiContext
    {
        Task<TResponse> SendRequestAsync<TResponse>(string url, Method method, string token, CancellationToken cancellationToken)
            where TResponse : class, new();

        Task<TResponse> SendRequestAsync<TResponse>(string url, Method method, string token, string resourse, IEnumerable<KeyValuePair<string, object>> urlSegments, CancellationToken cancellationToken) 
            where TResponse : class, new();

        Task<TResponse> SendRequestAsync<TResponse, TBodyRequest>(string url, Method method, string token, TBodyRequest bodyRequest, CancellationToken cancellationToken) 
            where TBodyRequest : class, new()
            where TResponse : class, new();
    }
}
