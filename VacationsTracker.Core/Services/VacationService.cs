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
        public async Task<VacationModel> CreateOrUpdateVacation(VacationModel model)
        {
            await Task.Delay(500);
            model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;

            return model;
        }

        public async Task<VacationModel> GetVacationById(Guid id)
        {
            await Task.Delay(10);

            return new VacationModel()
            {
                Id = id,
                VacationStatus = VacationStatus.Approved,
                VacationType = VacationType.Exceptional,
                Created = DateTime.Now,
                CreatedBy = "Root",
                End = DateTime.Today,
                Start = DateTime.Today.AddDays(10)
            };
        }

        public async Task<IEnumerable<VacationModel>> GetVacations()
        {
            await Task.Delay(500);

            var vacations = new VacationModel[]
            {
                new VacationModel()
                {
                    VacationStatus = VacationStatus.Approved, VacationType = VacationType.Exceptional,
                    Id = Guid.NewGuid(), Start = new DateTime(2019, 02, 20), End = new DateTime(2019, 02, 30)
                },
                new VacationModel()
                {
                    VacationStatus = VacationStatus.Closed, VacationType = VacationType.Overtime, Id = Guid.NewGuid(),
                    Start = new DateTime(2019, 03, 25), End = new DateTime(2019, 03, 26)
                },
                new VacationModel()
                {
                    VacationStatus = VacationStatus.Approved, VacationType = VacationType.Regular, Id = Guid.NewGuid(),
                    Start = new DateTime(2019, 04, 31), End = new DateTime(2019, 05, 29)
                },
                new VacationModel()
                {
                    VacationStatus = VacationStatus.Closed, VacationType = VacationType.Sick, Id = Guid.NewGuid(),
                    Start = new DateTime(2019, 03, 01), End = new DateTime(2019, 03, 12)
                },
                new VacationModel()
                {
                    VacationStatus = VacationStatus.Closed, VacationType = VacationType.Regular, Id = Guid.NewGuid(),
                    Start = new DateTime(2019, 04, 20), End = new DateTime(2019, 04, 27)
                },
                new VacationModel()
                {
                    VacationStatus = VacationStatus.Closed, VacationType = VacationType.Exceptional,
                    Id = Guid.NewGuid(), Start = new DateTime(2019, 04, 12), End = new DateTime(2019, 06, 09)
                },
            };

            return vacations;
        }

        public async Task<bool> RemoveVacationById(Guid id)
        {
            await Task.Delay(500);

            return true;
        }
    }
}
