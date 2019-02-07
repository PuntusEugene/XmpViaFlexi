using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using VacationsTracker.Core.Domain.Vacation;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.Vacation.Parameters;
using VacationsTracker.Core.Services.Interfaces;

namespace VacationsTracker.Core.Presentation.ViewModels.Vacation
{
    public class VacationDetailsViewModel : ViewModelBase<VacationDetailsParameters>
    {

        private INavigationService _navigationService;
        private IVacationService _vacationService;
        private VacationStatus _vacationStatus;

        public VacationStatus VacationStatus
        {
            get => _vacationStatus;
            set => Set(ref _vacationStatus, value);
        }

        public ICommand BackToHomeCommand => CommandProvider.Get(NavigateToDetails);

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
                var vacation = await _vacationService.GetVacationById(parameters.Guid);
                VacationStatus = vacation.VacationStatus;
            }
        }

        private void NavigateToDetails()
        {
            _navigationService.NavigateBackToHome(this);
        }
    }
}
