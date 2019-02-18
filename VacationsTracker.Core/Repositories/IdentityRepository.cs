using System.Threading;
using System.Threading.Tasks;
using VacationsTracker.Core.Api.Interfaces;
using VacationsTracker.Core.DataTransferObjects;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Repositories.Interfaces;

namespace VacationsTracker.Core.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly IIdentityApi _identityApi;

        public IdentityRepository(IIdentityApi identityApi)
        {
            _identityApi = identityApi;
        }

        public async Task AuthenticationAsync(UserCredentialModel userCredentialModel, CancellationToken cancellationToken)
        {
            await _identityApi.AuthenticationAsync(userCredentialModel.ToVacationDTO(), cancellationToken); 
        }

        public void Logout()
        {
            _identityApi.Logout();
        }
    }
}