using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VacationsTracker.Core.Api.Interfaces;
using VacationsTracker.Core.DataTransferObjects;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Domain.Vacation;
using VacationsTracker.Core.Repositories.Interfaces;

namespace VacationsTracker.Core.Repositories
{
    public class VacationRepository : IVacationRepository
    {
        private readonly IVacationApi _vacationApi;

        public VacationRepository(IVacationApi vacationApi)
        {
            _vacationApi = vacationApi;
        }

        public async Task<VacationModel> CreateOrUpdateVacationAsync(VacationModel model)
        {
            var dto = model.ToVacationDTO();
            var vacationDto = await _vacationApi.CreateOrUpdateVacationAsync(dto);
            return vacationDto.ToVacationModel();
        }

        public async Task<VacationModel> GetVacationByIdAsync(Guid id)
        {
            var vacationDto = await _vacationApi.GetVacationAsync(id);
            return vacationDto.ToVacationModel();
        }
       

        public async Task<IEnumerable<VacationModel>> GetVacationsAsync()
        {
            var vacationDto = await _vacationApi.GetVacationCollectionAsync();
            return vacationDto.ToVacationModel();
        }

        public async Task<bool> DeleteVacationByIdAsync(Guid id)
        {
            var vacationDto = await _vacationApi.DeleteVacationAsync(id);
            return vacationDto.ToVacationModel();
        }
    }
}
