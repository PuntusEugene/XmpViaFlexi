using System;
using System.Threading.Tasks;
using VacationsTracker.Core.Api.Interfaces;
using VacationsTracker.Core.DataTransferObjects;
using VacationsTracker.Core.Infrastructure.Storage;

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

        public async Task<bool> AuthenticationAsync(UserCredentialDTO userCredentialModel)
        {
            var isSuccessAuthentication = userCredentialModel.Login == "ark" && userCredentialModel.Password == "123";

            if (!isSuccessAuthentication)
                return false;

            await _secureStorage.SetAsync(_tokenKey, Guid.NewGuid().ToString());
            return true;
        }

        public async Task<bool> AuthorizationAsync()
        {
            var token = await _secureStorage.GetAsync(_tokenKey);
            return token != null;
        }

        public bool Logout()
        {
            return _secureStorage.Remove(_tokenKey);
        }
    }
}
