namespace VacationsTracker.Core.Api
{
    internal static class ApiSettings
    {
        public static readonly string SwaggerServiceUrl = "https://vts-v2.azurewebsites.net/api/vts/workflow";
        public static readonly string IdentityServiceUrl = "https://vts-token-issuer-v2.azurewebsites.net";

        public static readonly string ClientIdForSwagger = "VTS-Swagger-v1";
        public static readonly string ClientId = "VTS-Mobile-v1";
        public static readonly string ClientSecret = "VTS123456789";
        public static readonly string Scope = "VTS-Server-v2";

        public static readonly string DateFormatString = "yyyy-MM-ddTHH:mm:ss";
    }
}
