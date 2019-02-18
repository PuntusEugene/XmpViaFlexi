using System;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using VacationsTracker.Core.Api.Interfaces;
using VacationsTracker.Core.DataTransferObjects;
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

        public async Task AuthenticationAsync(UserCredentialDTO userCredentialModel, CancellationToken cancellationToken)
        {
            var identityServer = await DiscoveryClient.GetAsync(SettingApi.IdentityServiceUrl);

            if (identityServer.IsError)
            {
                throw new AuthenticationException(Strings.NotConnectToIdentity);
            }

            var authClient = new TokenClient(
                identityServer.TokenEndpoint,
                SettingApi.ClientId,
                SettingApi.ClientSecret);

            var userTokenResponse = await authClient.RequestResourceOwnerPasswordAsync(
                userName: userCredentialModel.Login,
                password: userCredentialModel.Password,
                scope: SettingApi.Scope,
                cancellationToken: cancellationToken);

            if (userTokenResponse.IsError || userTokenResponse.AccessToken == null)
            {
                throw new AuthenticationException(Strings.InitializeTokeException);
            }

            //var isSuccessAuthentication = userCredentialModel.Login == "ark" && userCredentialModel.Password == "123";

            //if (!isSuccessAuthentication)
            //    throw new AuthenticationException();

            await _secureStorage.SetAsync(_tokenKey, userTokenResponse.AccessToken);
        }

        public async Task<string> AuthorizationAsync()
        {
            var token = await _secureStorage.GetAsync(_tokenKey);

            if(token == null)
                throw new AuthenticationException();

            return token;
        }

        public void Logout()
        {
            _secureStorage.Remove(_tokenKey);
        }
    }
}
