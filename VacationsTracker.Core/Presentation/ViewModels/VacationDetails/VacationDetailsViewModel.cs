using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Domain.Vacation;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails.VacationPager;
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
        private readonly INavigationService _navigationService;
        private readonly IVacationService _vacationService;
        
        public VacationType VacationType
        {
            get => _vacationType;
            set => Set(ref _vacationType, value);
        }

        public DateTime DateBegin
        {
            get => _dateBegin;
            set
            {
                Set(ref _dateBegin, value);

                if (_dateBegin > _dateEnd)
                    DateEnd = _dateBegin;
            }
        }

        public DateTime DateEnd
        {
            get => _dateEnd;
            set
            {
                Set(ref _dateEnd, value);

                if (_dateEnd < _dateBegin)
                    DateBegin = _dateEnd;
            }
        }

        public VacationStatus VacationStatus
        {
            get => _vacationStatus;
            set => Set(ref _vacationStatus, value);
        }

        public ObservableCollection<VacationTypePagerParameters> VacationTypes { get; }

        public ICommand BackToHomeCommand => CommandProvider.Get(BackToHome);

        public ICommand SaveVacationCommand => CommandProvider.GetForAsync(SaveVacation);

        public VacationDetailsViewModel(INavigationService navigationService, IVacationService vacationService)
        {
            _navigationService = navigationService;
            _vacationService = vacationService;

            VacationTypes = new ObservableCollection<VacationTypePagerParameters>(
                Enum.GetValues(typeof(VacationType))
                    .Cast<VacationType>().Select(t => new VacationTypePagerParameters(t)));
        }

        protected override async Task InitializeAsync(VacationDetailsParameters parameters)
        {
            await base.InitializeAsync(parameters);

            if (parameters != null)
            {
                var vacation = await _vacationService.GetVacationById(parameters.Id);
                _id = vacation.Id;
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
                Id = _id,
                VacationStatus = this.VacationStatus,
                VacationType = this.VacationType,
                Start = this.DateBegin,
                End = this.DateEnd,
                Created = DateTime.Now,
            };

            await _vacationService.CreateOrUpdateVacation(vacationModel);

            BackToHome();
        }
    }

}
