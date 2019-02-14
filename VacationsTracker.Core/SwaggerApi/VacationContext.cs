using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using VacationsTracker.Core.SwaggerApi;
using VacationsTracker.Core.SwaggerApi.Interfaces;

namespace VacationsTracker.Core.SwaggerApi
{
    public class VacationContext : IVacationContext
    {
        public async Task<TResponse> SendRequestAsync<TResponse>(string url, Method method) where TResponse : class
        {
            return await SendRequestAsync<TResponse, object>(url, method, null);
        }

        public async Task<TResponse> SendRequestAsync<TResponse, TRequest>(string url, Method method,TRequest bodyRequest)
            where TRequest : class
            where TResponse : class
        {
            var client = new RestClient(url);
            var request = new RestRequest(method);

            if (bodyRequest != null)
            {
                request.AddJsonBody(bodyRequest);
            }

            var response = await client.ExecuteTaskAsync<TResponse>(request);

            return response.Data;
        }
    }
}
