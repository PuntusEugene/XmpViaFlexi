using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using VacationsTracker.Core.Api.Interfaces;

namespace VacationsTracker.Core.Api
{
    public class VacationHttpApiContext : IVacationApiContext
    {
        public async Task<TResponse> SendRequestAsync<TResponse>(string url, Method method, string token)
            where TResponse : class, new()
        {
            return await SendRequestAsync<TResponse, object>(url, method, token, null);
        }

        public async Task<TResponse> SendRequestAsync<TResponse>(string url, Method method, string token, string resourse, IEnumerable<KeyValuePair<string, object>> urlSegments)
            where TResponse : class, new()
        {

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            var tempUrl = Path.Combine(url, resourse);

            foreach (var urlSegment in urlSegments)
            {
                tempUrl = tempUrl.Replace("{"+ urlSegment.Key+ "}", urlSegment.Value.ToString());
            }

            var httpRequest = new HttpRequestMessage(GetMethod(method), tempUrl);


            var response = await client.SendAsync(httpRequest);
            var contentString = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<TResponse>(contentString);

            return obj;
        }

        public async Task<TResponse> SendRequestAsync<TResponse, TRequest>(string url, Method method, string token, TRequest bodyRequest)
            where TRequest : class, new()
            where TResponse : class, new()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var httpRequest = new HttpRequestMessage(GetMethod(method), url);

            if (bodyRequest != null)
            {
                httpRequest.Content = new StringContent(JsonConvert.SerializeObject(bodyRequest), Encoding.UTF8,
                    "application/json");
            }

            var response = await client.SendAsync(httpRequest);
            var contentString = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<TResponse>(contentString);

            return obj;
        }

        private HttpMethod GetMethod(Method method)
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
