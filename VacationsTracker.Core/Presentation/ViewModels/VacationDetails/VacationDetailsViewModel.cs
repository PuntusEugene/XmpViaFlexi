using System;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Domain.Vacation;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails.Parameters;
using VacationsTracker.Core.Services.Interfaces;

namespace VacationsTracker.Core.Presentation.ViewModels.VacationDetails
{
    public class VacationDetailsViewModel : ViewModelBase<VacationDetailsParameters>
    {
        private Guid _id;
        private VacationType _vacationType;
        private DateTime _dateBegin;
        private DateTime _dateEnd;
        private VacationStatus _vacationStatus;
        private INavigationService _navigationService;
        private IVacationService _vacationService;

        public Guid Id
        {
            get => _id;
            set => Set(ref _id, value);
        }

        public VacationType VacationType
        {
            get => _vacationType;
            set => Set(ref _vacationType, value);
        }

        public DateTime DateBegin
        {
            get => _dateBegin;
            set => Set(ref _dateBegin, value);
        }

        public DateTime DateEnd
        {
            get => _dateEnd;
            set => Set(ref _dateEnd, value);
        }

        public VacationStatus VacationStatus
        {
            get => _vacationStatus;
            set => Set(ref _vacationStatus, value);
        }

        public ICommand BackToHomeCommand => CommandProvider.Get(BackToHome);

        public ICommand SaveVacationCommand => CommandProvider.GetForAsync(SaveVacation);

        public VacationDetailsViewModel(INavigationService navigationService, IVacationService vacationService)
        {
            _navigationService = navigationService;
            _vacationService = vacationService;
        }

        protected override async Task InitializeAsync(VacationDetailsParameters parameters)
        {
            await base.InitializeAsync(parameters);

            if (parameters != null)
            {
                var vacation = await _vacationService.GetVacationById(parameters.Id);
                Id = vacation.Id;
                VacationType = vacation.VacationType;
                DateBegin = vacation.Start;
                DateEnd = vacation.End;
                VacationStatus = vacation.VacationStatus;
            }
        }

        private void BackToHome()
        {
            _navigationService.NavigateBackToHome(this);
        }

        private async Task SaveVacation()
        {
            var vacationModel = new VacationModel()
            {
                Id = Id,
                VacationStatus = this.VacationStatus,
                VacationType = this.VacationType,
                Start = this.DateBegin,
                End = this.DateEnd,
                Created = DateTime.Now,
            };

            await _vacationService.CreateOrUpdateVacation(vacationModel);

            //BackToHome();
        }
    }
}
