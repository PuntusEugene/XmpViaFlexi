using System;
using System.Collections.Generic;
using System.Text;

namespace VacationsTracker.Core.Api
{
    internal static class SettingApi
    {
        public static readonly string SwaggerServiceUrl = "https://vts-v2.azurewebsites.net/api/vts/workflow";
        public static readonly string IdentityServiceUrl = "https://vts-token-issuer-v2.azurewebsites.net";

        public static readonly string ClientIdForSwagger = "VTS-Swagger-v1";
        public static readonly string ClientId = "VTS-Mobile-v1";
        public static readonly string ClientSecret = "VTS123456789";
        public static readonly string Scope = "VTS-Server-v2";
    }
}
