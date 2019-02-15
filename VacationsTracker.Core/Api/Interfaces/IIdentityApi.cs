using System.Threading.Tasks;
using VacationsTracker.Core.DataTransferObjects;

namespace VacationsTracker.Core.Api.Interfaces
{
    public interface IIdentityApi
    {
        Task<bool> AuthenticationAsync(UserCredentialDTO userCredentialModel);

        Task<bool> AuthorizationAsync();

        bool Logout();
    }
}
