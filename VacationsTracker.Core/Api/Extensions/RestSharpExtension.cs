using System.Collections.Generic;
using RestSharp;

namespace VacationsTracker.Core.Api.Extensions
{
    public static class RestSharpExtension
    {
        public static IRestRequest AddUrlSegments(this IRestRequest restRequest, string resourse,  IEnumerable<KeyValuePair<string, string>> urlSegments)
        {
            restRequest.Resource = resourse;

            foreach (var urlSegment in urlSegments)
            {
                restRequest.AddUrlSegment(urlSegment.Key, urlSegment.Value);
            }

            return restRequest;
        }
    }
}
