using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Domain.Vacation;
using VacationsTracker.Core.Services.Interfaces;

namespace VacationsTracker.Core.Services
{
    public class VacationService : IVacationService
    {
        public async Task<VacationRequest> CreateOrUpdateVacation(VacationRequest model)
        {
            await Task.Delay(500);
            if (model.Id == Guid.Empty)
                model.Id = Guid.NewGuid();

            return model;
        }

        public async Task<VacationRequest> GetVacationById(Guid id)
        {
            await Task.Delay(500);

            return new VacationRequest()
            {
                Id = id,
                VacationStatus = VacationStatus.Approved,
                VacationType = VacationType.Exceptional,
                Created = DateTime.Now,
                CreatedBy = "Root",
                End = DateTime.Today,
                Start = DateTime.Today
            };
        }

        public async Task<BaseResultOfVacationRequest> GetVacations()
        {
            await Task.Delay(500);

            return new BaseResultOfVacationRequest()
            {
                Code = "OK",
                Result = new []
                {
                    await GetVacationById(Guid.NewGuid()),
                    await GetVacationById(Guid.NewGuid()),
                    await GetVacationById(Guid.NewGuid()),
                    await GetVacationById(Guid.NewGuid()),
                    await GetVacationById(Guid.NewGuid())
                }
            };
        }

        public async Task<BaseResult> RemoveVacationById(Guid id)
        {
            await Task.Delay(500);

            return new BaseResult() {Code = "OK", Message = string.Empty};
        }
    }
}
