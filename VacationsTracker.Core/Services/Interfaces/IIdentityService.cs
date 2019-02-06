using System.Threading.Tasks;

namespace VacationsTracker.Core.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> AuthorizationAsync(string login, string password);
    }
}
