using System.Threading;
using System.Threading.Tasks;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Repositories.Interfaces
{
    public interface IIdentityRepository
    {
        Task<bool> AuthenticationAsync(UserCredentialModel userCredentialModel, CancellationToken cancellationToken);

        bool Logout();
    }
}
