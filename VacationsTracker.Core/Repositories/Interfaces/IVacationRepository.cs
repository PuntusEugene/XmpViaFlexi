using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Repositories.Interfaces
{
    public interface IVacationRepository
    {
        Task<VacationModel> CreateOrUpdateVacationAsync(VacationModel model);

        Task<IEnumerable<VacationModel>> GetVacationsAsync();

        Task<VacationModel> GetVacationByIdAsync(Guid id);

        Task<bool> DeleteVacationByIdAsync(Guid id);
    }
}
