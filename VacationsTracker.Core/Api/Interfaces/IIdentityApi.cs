using System.Threading;
using System.Threading.Tasks;
using VacationsTracker.Core.DataTransferObjects;

namespace VacationsTracker.Core.Api.Interfaces
{
    public interface IIdentityApi
    {
        Task LoginAsync(UserCredentialDTO userCredentialModel, CancellationToken cancellationToken);

        Task<string> GetAuthorizationTokenAsync();

        void Logout();
    }
}
