using System.Threading;
using System.Threading.Tasks;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Repositories.Interfaces
{
    public interface IIdentityRepository
    {
        Task AuthenticationAsync(UserCredentialModel userCredentialModel, CancellationToken cancellationToken);

        void Logout();
    }
}
