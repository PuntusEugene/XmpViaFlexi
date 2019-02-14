using System.Threading.Tasks;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Repositories.Interfaces
{
    public interface IIdentityRepository
    {
        Task<bool> AuthorizationAsync(UserCredentialModel userCredentialModel);
    }
}
