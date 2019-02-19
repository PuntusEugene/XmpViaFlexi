using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using VacationsTracker.Core.Api.Parameters;

namespace VacationsTracker.Core.Api.Interfaces
{
    public interface IVacationApiContext
    {
        Task<TResponse> SendRequestAsync<TResponse>(string url, Method method, string token, CancellationToken cancellationToken)
            where TResponse : class, new();

        Task<TResponse> SendRequestAsync<TResponse>(SharedContextParameters parameters, CancellationToken cancellationToken) 
            where TResponse : class, new();

        Task<TResponse> SendRequestAsync<TResponse, TBodyRequest>(SharedContextParameters parameters, TBodyRequest bodyRequest, CancellationToken cancellationToken) 
            where TBodyRequest : class, new()
            where TResponse : class, new();
    }
}
