using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VacationsTracker.Core.Api.Interfaces;
using VacationsTracker.Core.DataTransferObjects;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Repositories.Interfaces;

namespace VacationsTracker.Core.Repositories
{
    internal class VacationRepository : IVacationRepository
    {
        private readonly IVacationApi _vacationApi;

        public VacationRepository(IVacationApi vacationApi)
        {
            _vacationApi = vacationApi;
        }

        public async Task<VacationModel> CreateOrUpdateVacationAsync(VacationModel model, CancellationToken cancellationToken)
        {
            var dto = model.ToVacationDTO();
            var vacationDto = await _vacationApi.CreateOrUpdateVacationAsync(dto, cancellationToken);
            return vacationDto.ToVacationModel();
        }

        public async Task<VacationModel> GetVacationByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var vacationDto = await _vacationApi.GetVacationAsync(id, cancellationToken);
            return vacationDto.ToVacationModel();
        }
       

        public async Task<IEnumerable<VacationModel>> GetVacationsAsync(CancellationToken cancellationToken)
        {
            var vacationDto = await _vacationApi.GetVacationCollectionAsync(cancellationToken);
            return vacationDto.ToVacationModel();
        }

        public async Task<bool> DeleteVacationByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var vacationDto = await _vacationApi.DeleteVacationAsync(id, cancellationToken);
            return vacationDto.ToVacationModel();
        }
    }
}
