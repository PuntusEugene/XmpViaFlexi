using System;
using System.Collections.Generic;
using RestSharp;

namespace VacationsTracker.Core.Api.Parameters
{
    public sealed class SharedContextParameters
    {
        private IDictionary<string, string> _urlSegments;

        public string Url { get; }

        public Method Method { get; }

        public string Token { get; }

        public string Resourse { get; private set; }

        public IEnumerable<KeyValuePair<string, string>> UrlSegments => _urlSegments;

        public SharedContextParameters(string url, Method method, string token)
        {
            Url = url;
            Method = method;
            Token = token;
            Resourse = string.Empty;
            _urlSegments = new Dictionary<string, string>();
        }

        public SharedContextParameters AddUrlSegment(string resourse, string name, string value)
        {
            Resourse = resourse;
            _urlSegments.Add(name, value);
            return this;
        }

        public SharedContextParameters AddUrlSegment(string resourse, string name, Guid value)
        {
            Resourse = resourse;
            _urlSegments.Add(name, value.ToString());
            return this;
        }
    }
}
