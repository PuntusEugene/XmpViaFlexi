using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Services.Interfaces
{
    public interface IVacationService
    {
        Task<VacationModel> CreateOrUpdateVacation(VacationModel model);

        Task<IEnumerable<VacationModel>> GetVacations();

        Task<VacationModel> GetVacationById(Guid id);

        Task<bool> RemoveVacationById(Guid id);
    }
}
