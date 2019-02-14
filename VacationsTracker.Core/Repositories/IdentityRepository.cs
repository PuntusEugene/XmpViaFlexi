using System.Threading.Tasks;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Repositories.Interfaces;

namespace VacationsTracker.Core.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        public async Task<bool> AuthorizationAsync(UserCredentialModel userCredentialModel)
        {
            await Task.Delay(500);
            return userCredentialModel.Login == "ark" && userCredentialModel.Password == "123";
        }
    }
}