using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using VacationsTracker.Core.Api.Extensions;
using VacationsTracker.Core.Api.Interfaces;
using VacationsTracker.Core.Api.Parameters;
using VacationsTracker.Core.Domain.Exceptions;
using VacationsTracker.Core.Resourses;

namespace VacationsTracker.Core.Api
{
    public class VacationRestApiContext : IVacationApiContext
    {
        public async Task<TResponse> SendRequestAsync<TResponse>(string url, Method method, string token, CancellationToken cancellationToken)
            where TResponse : class, new()
        {
            return await SendRequestAsync<TResponse, object>(new SharedContextParameters(url, method, token), null, cancellationToken);
        }

        public async Task<TResponse> SendRequestAsync<TResponse>(SharedContextParameters parameters, CancellationToken cancellationToken)
            where TResponse : class, new()
        {
            return await SendRequestAsync<TResponse, object>(parameters, null, cancellationToken);
        }

        public async Task<TResponse> SendRequestAsync<TResponse, TBodyRequest>(SharedContextParameters parameters, TBodyRequest bodyRequest, CancellationToken cancellationToken)
            where TBodyRequest : class, new()
            where TResponse : class, new()
        {
            var client = new RestClient(parameters.Url)
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(parameters.Token, "Bearer")
            };

            var jsonBody = JsonConvert.SerializeObject(bodyRequest);

            var request = new RestRequest(parameters.Method)
                .AddJsonBody(jsonBody)
                .AddUrlSegments(parameters.Resourse, parameters.UrlSegments);

            var response = await client.ExecuteTaskAsync(request, cancellationToken);
            
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new AuthorizationException(Strings.NotActiveToken);
            }
            
            return JsonConvert.DeserializeObject<TResponse>(response.Content);
        }
    }

}
