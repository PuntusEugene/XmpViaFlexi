using System.Diagnostics;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using VacationsTracker.Core.Api.Interfaces;
using VacationsTracker.Core.DataTransferObjects;
using VacationsTracker.Core.Domain.Exceptions;
using VacationsTracker.Core.Infrastructure.Storage;
using VacationsTracker.Core.Resourses;

namespace VacationsTracker.Core.Api
{
    public class IdentityApi : IIdentityApi
    {
        private readonly IVacationSecureStorage _secureStorage;
        private readonly string _tokenKey = "id_token";

        public IdentityApi(IVacationSecureStorage secureStorage)
        {
            _secureStorage = secureStorage;
        }

        public async Task LoginAsync(UserCredentialDTO userCredentialModel, CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiSettings.IdentityServiceUrl), cancellationToken);
            var responseContent = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseContent);

            var identityServer = await DiscoveryClient.GetAsync(ApiSettings.IdentityServiceUrl);

            if (identityServer.IsError)
            {
                throw new AuthenticationException(Strings.NotConnectToIdentity);
            }

            var authClient = new TokenClient(
                identityServer.TokenEndpoint,
                ApiSettings.ClientId,
                ApiSettings.ClientSecret);

            var userTokenResponse = await authClient.RequestResourceOwnerPasswordAsync(
                userCredentialModel.Login,
                userCredentialModel.Password,
                ApiSettings.Scope,
                cancellationToken: cancellationToken);

            if (userTokenResponse.IsError || userTokenResponse.AccessToken == null)
            {
                throw new AuthenticationException(Strings.InitializeTokeException);
            }

            await _secureStorage.SetAsync(_tokenKey, userTokenResponse.AccessToken);
        }

        public async Task<string> GetAuthorizationTokenAsync()
        {
            var token = await _secureStorage.GetAsync(_tokenKey);

            if(token != null)
            {
                return token;
            }

            throw new AuthorizationException(Strings.NotActiveToken);

        }

        public void Logout()
        {
            _secureStorage.Remove(_tokenKey);
        }
    }
}
