using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using VacationsTracker.Core.Api.Interfaces;

namespace VacationsTracker.Core.Api
{
    public class VacationApiContext : IVacationApiContext
    {
        public async Task<TResponse> SendRequestAsync<TResponse>(string url, Method method)
            where TResponse : class, new()
        {
            return await SendRequestAsync<TResponse, object>(url, method, null);
        }

        public Task<TResponse> SendRequestAsync<TResponse>(string url, Method method, string resourse, IEnumerable<KeyValuePair<string, object>> urlSegments)
            where TResponse : class, new()
        {
            var client = new RestClient(url);
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(@"eyJhbGciOiJSUzI1NiIsImtpZCI6ImEyNmQyNGY2NTYyMzVhNjcxZmNlMzBmZmNiN2UwNmMzIiwidHlwIjoiSldUIn0.eyJuYmYiOjE1NTAyNDQ1OTksImV4cCI6MTU1MDI0ODE5OSwiaXNzIjoiaHR0cHM6Ly92dHMtdG9rZW4taXNzdWVyLXYyLmF6dXJld2Vic2l0ZXMubmV0IiwiYXVkIjpbImh0dHBzOi8vdnRzLXRva2VuLWlzc3Vlci12Mi5henVyZXdlYnNpdGVzLm5ldC9yZXNvdXJjZXMiLCJWVFMtU2VydmVyLXYyIl0sImNsaWVudF9pZCI6IlZUUy1Td2FnZ2VyLXYxIiwic3ViIjoiMSIsImF1dGhfdGltZSI6MTU1MDE0NTY1NiwiaWRwIjoibG9jYWwiLCJzY29wZSI6WyJWVFMtU2VydmVyLXYyIl0sImFtciI6WyJwd2QiXX0.GuC62-v2pNs9h_iQedqk2NfeKpNHDM7A_oy1aXDzY36r4_v_dA2k5zSajDEUMvF2WGUg30XoEy167zfbcOajXEt472qqAREJ_j2NjNYGduxhn3oPUgBXMoIj_Q9bU5DXVWvF7wjJk4BLMefXhnOncPCH-OVlk0UNmFvbXOpyU6nu_2ysGoT8fXzKdGPI2XftjUmSHV-YxsIvvcWGLBu5br-N1tkdtePAned7RLPGijHlCu-73-6C9pem4r4_KthxezZIZBRgx30YfcEUag-073O-NwbbWZmpNOtny-4cGMekb0c9iwflpO78WGcxotuiGqes0G0GQOJRygmFFNZyQw", "Bearer");

            var request = new RestRequest(resourse, method);

            foreach (var urlSegment in urlSegments)
            {
                request.AddUrlSegment(urlSegment.Key, urlSegment.Value);
            }

            var taskCompletionSource = new TaskCompletionSource<TResponse>();

            client.ExecuteAsync(request, response =>
            {
                Debug.WriteLine(response.Content);
                var obj = JsonConvert.DeserializeObject<TResponse>(response.Content);
                taskCompletionSource.SetResult(obj);
            });

            return taskCompletionSource.Task;

            //var response = await client.ExecuteTaskAsync<TResponse>(request);

            //return response.Data;
        }

        public Task<TResponse> SendRequestAsync<TResponse, TRequest>(string url, Method method, TRequest bodyRequest)
            where TRequest : class, new()
            where TResponse : class, new()
        {
            var client = new RestClient(url);
            client.Authenticator= new OAuth2AuthorizationRequestHeaderAuthenticator(@"eyJhbGciOiJSUzI1NiIsImtpZCI6ImEyNmQyNGY2NTYyMzVhNjcxZmNlMzBmZmNiN2UwNmMzIiwidHlwIjoiSldUIn0.eyJuYmYiOjE1NTAyNDQ1OTksImV4cCI6MTU1MDI0ODE5OSwiaXNzIjoiaHR0cHM6Ly92dHMtdG9rZW4taXNzdWVyLXYyLmF6dXJld2Vic2l0ZXMubmV0IiwiYXVkIjpbImh0dHBzOi8vdnRzLXRva2VuLWlzc3Vlci12Mi5henVyZXdlYnNpdGVzLm5ldC9yZXNvdXJjZXMiLCJWVFMtU2VydmVyLXYyIl0sImNsaWVudF9pZCI6IlZUUy1Td2FnZ2VyLXYxIiwic3ViIjoiMSIsImF1dGhfdGltZSI6MTU1MDE0NTY1NiwiaWRwIjoibG9jYWwiLCJzY29wZSI6WyJWVFMtU2VydmVyLXYyIl0sImFtciI6WyJwd2QiXX0.GuC62-v2pNs9h_iQedqk2NfeKpNHDM7A_oy1aXDzY36r4_v_dA2k5zSajDEUMvF2WGUg30XoEy167zfbcOajXEt472qqAREJ_j2NjNYGduxhn3oPUgBXMoIj_Q9bU5DXVWvF7wjJk4BLMefXhnOncPCH-OVlk0UNmFvbXOpyU6nu_2ysGoT8fXzKdGPI2XftjUmSHV-YxsIvvcWGLBu5br-N1tkdtePAned7RLPGijHlCu-73-6C9pem4r4_KthxezZIZBRgx30YfcEUag-073O-NwbbWZmpNOtny-4cGMekb0c9iwflpO78WGcxotuiGqes0G0GQOJRygmFFNZyQw", "Bearer");

            var request = new RestRequest(method);

            if (bodyRequest != null)
            {
                request.AddJsonBody(bodyRequest);
            }

            var taskCompletionSource = new TaskCompletionSource<TResponse>();

            client.ExecuteAsync(request, response =>
            {
                Debug.WriteLine(response.Content);
                var obj = JsonConvert.DeserializeObject<TResponse>(response.Content);
                taskCompletionSource.SetResult(obj);
            });

            return taskCompletionSource.Task;

            //var response = await client.ExecuteTaskAsync<TResponse>(request);

            //return response.Data;
        }
    }
}
