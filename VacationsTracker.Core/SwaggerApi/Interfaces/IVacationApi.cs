using System;
using System.Threading.Tasks;
using VacationsTracker.Core.DataTransferObjects;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.SwaggerApi.Interfaces
{
    public interface IVacationApi
    {
        Task<BaseResultOfVacationDTO> GetVacationCollectionAsync();

        Task<VacationDTO> CreateOrUpdateVacationAsync(VacationDTO vacationDto);

        Task<VacationDTO> GetVacationAsync(Guid id);

        Task<BaseResultDTO> DeleteVacationAsync(Guid id);
    }
}
