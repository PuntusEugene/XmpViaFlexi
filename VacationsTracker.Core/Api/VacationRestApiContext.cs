using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using VacationsTracker.Core.Api.Interfaces;

namespace VacationsTracker.Core.Api
{
    public class VacationRestApiContext : IVacationApiContext
    {
        public async Task<TResponse> SendRequestAsync<TResponse>(string url, Method method, string token)
            where TResponse : class, new()
        {
            return await SendRequestAsync<TResponse, object>(url, method, token, null);
        }

        public async Task<TResponse> SendRequestAsync<TResponse>(string url, Method method, string token, string resourse, IEnumerable<KeyValuePair<string, object>> urlSegments)
            where TResponse : class, new()
        {
            var client = new RestClient(url)
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer")
            };
            
            var request = new RestRequest(resourse, method);

            foreach (var urlSegment in urlSegments)
            {
                request.AddUrlSegment(urlSegment.Key, urlSegment.Value);
            }

            var response = await client.ExecuteTaskAsync(request);
            var data = JsonConvert.DeserializeObject<TResponse>(response.Content);

            return data;
        }

        public async Task<TResponse> SendRequestAsync<TResponse, TRequest>(string url, Method method, string token, TRequest bodyRequest)
            where TRequest : class, new()
            where TResponse : class, new()
        {
            var client = new RestClient(url)
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer")
            };

            var request = new RestRequest(method);

            if (bodyRequest != null)
            {
                request.AddJsonBody(bodyRequest);
            }

            var response = await client.ExecuteTaskAsync(request);
            var data = JsonConvert.DeserializeObject<TResponse>(response.Content);

            return data;

        }
    }
}
