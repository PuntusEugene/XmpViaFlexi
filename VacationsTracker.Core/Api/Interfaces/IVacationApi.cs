using System;
using System.Threading.Tasks;
using VacationsTracker.Core.DataTransferObjects;

namespace VacationsTracker.Core.Api.Interfaces
{
    public interface IVacationApi
    {
        Task<BaseResultOfVacationCollectionDTO> GetVacationCollectionAsync();

        Task<BaseResultOfVacationDTO> CreateOrUpdateVacationAsync(VacationDTO vacationDto);

        Task<BaseResultOfVacationDTO> GetVacationAsync(Guid id);

        Task<BaseResultDTO> DeleteVacationAsync(Guid id);
    }
}
