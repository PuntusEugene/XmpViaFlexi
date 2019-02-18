using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Repositories.Interfaces
{
    public interface IVacationRepository
    {
        Task<VacationModel> CreateOrUpdateVacationAsync(VacationModel model, CancellationToken cancellationToken);

        Task<IEnumerable<VacationModel>> GetVacationsAsync(CancellationToken cancellationToken);

        Task<VacationModel> GetVacationByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<bool> DeleteVacationByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
