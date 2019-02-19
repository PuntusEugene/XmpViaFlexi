using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using VacationsTracker.Core.Api.Interfaces;
using VacationsTracker.Core.Api.Parameters;

namespace VacationsTracker.Core.Api
{
    public class VacationHttpApiContext : IVacationApiContext
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

        public async Task<TResponse> SendRequestAsync<TResponse, TRequest>(SharedContextParameters parameters, TRequest bodyRequest, CancellationToken cancellationToken)
            where TRequest : class, new()
            where TResponse : class, new()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", parameters.Token);

            var httpRequest = new HttpRequestMessage(GetHttpMethod(parameters.Method), parameters.Url);

            if (bodyRequest != null)
            {
                httpRequest.Content = new StringContent(JsonConvert.SerializeObject(bodyRequest, new JsonSerializerSettings() { DateFormatString = ApiSettings.DateFormatString }), Encoding.UTF8,
                    "application/json");
            }
            
            if (!string.IsNullOrWhiteSpace(parameters.Resourse))
            {
                var tempUrl = Path.Combine(parameters.Url, parameters.Resourse);

                foreach (var urlSegment in parameters.UrlSegments)
                {
                    tempUrl = tempUrl.Replace("{" + urlSegment.Key + "}", urlSegment.Value);
                }

                httpRequest.RequestUri = new Uri(tempUrl);
            }

            var response = await client.SendAsync(httpRequest, cancellationToken);
            var contentString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(contentString);
        }

        private HttpMethod GetHttpMethod(Method method)
        {
            switch (method)
            {
                case Method.GET:
                    return HttpMethod.Get;

                case Method.POST:
                    return HttpMethod.Post;

                case Method.DELETE:
                    return HttpMethod.Delete;

                default:
                    return HttpMethod.Post;
            }
        }
    }
}
