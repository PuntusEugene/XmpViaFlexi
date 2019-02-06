using System.Diagnostics;
using System.Threading.Tasks;
using VacationsTracker.Core.Services.Interfaces;

namespace VacationsTracker.Core.Services
{
    public class IdentityService : IIdentityService
    {
        public async Task<bool> AuthorizationAsync(string login, string password)
        {
            //await Task.Delay(1000);
            return true;//login == "ark" && password == "123";
        }
    }
}