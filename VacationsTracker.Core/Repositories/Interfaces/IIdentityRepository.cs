using System.Threading;
using System.Threading.Tasks;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Repositories.Interfaces
{
    public interface IIdentityRepository
    {
        Task LoginAsync(UserCredentialModel userCredentialModel, CancellationToken cancellationToken);

        void Logout();
    }
}
