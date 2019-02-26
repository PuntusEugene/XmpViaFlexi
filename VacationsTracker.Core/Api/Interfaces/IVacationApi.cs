using System;
using System.Threading;
using System.Threading.Tasks;
using VacationsTracker.Core.DataTransferObjects;

namespace VacationsTracker.Core.Api.Interfaces
{
    internal interface IVacationApi
    {
        Task<BaseResultOfVacationCollectionDTO> GetVacationCollectionAsync(CancellationToken cancellationToken);

        Task<BaseResultOfVacationDTO> CreateOrUpdateVacationAsync(VacationDTO vacationDto, CancellationToken cancellationToken);

        Task<BaseResultOfVacationDTO> GetVacationAsync(Guid id, CancellationToken cancellationToken);

        Task<BaseResultDTO> DeleteVacationAsync(Guid id, CancellationToken cancellationToken);
    }
}
