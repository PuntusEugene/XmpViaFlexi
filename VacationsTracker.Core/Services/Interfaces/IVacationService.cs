using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Services.Interfaces
{
    public interface IVacationService
    {
        Task<VacationRequest> CreateOrUpdateVacation(VacationRequest model);

        Task<BaseResultOfVacationRequest> GetVacations();

        Task<VacationRequest> GetVacationById(Guid id);

        Task<BaseResult> RemoveVacationById(Guid id);
    }
}
