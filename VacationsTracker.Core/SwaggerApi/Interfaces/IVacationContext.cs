using System.Threading.Tasks;
using RestSharp;

namespace VacationsTracker.Core.SwaggerApi.Interfaces
{
    public interface IVacationContext
    {
        Task<TResponse> SendRequestAsync<TResponse>(string url, Method method) where TResponse : class;

        Task<TResponse> SendRequestAsync<TResponse, TBodyRequest>(string url, Method method, TBodyRequest bodyRequest) where TBodyRequest : class where TResponse : class;
    }
}
