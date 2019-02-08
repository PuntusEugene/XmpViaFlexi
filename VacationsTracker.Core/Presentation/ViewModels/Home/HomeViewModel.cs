using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Domain.Vacation;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails.Parameters;
using VacationsTracker.Core.Services.Interfaces;

namespace VacationsTracker.Core.Presentation.ViewModels.Home
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationService _vacationService;
        private ObservableCollection<VacationItemViewModel> _vacations;

        public ObservableCollection<VacationItemViewModel> Vacations
        {
            get => _vacations;
            set => Set(ref _vacations, value);
        }

        public ICommand<VacationItemViewModel> VacationSelectedCommand => CommandProvider.Get<VacationItemViewModel>(NavigateToDetails);

        public HomeViewModel(INavigationService navigationService, IVacationService vacationService)
        {
            _navigationService = navigationService;
            _vacationService = vacationService;
        }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            
            var vacations = (await _vacationService.GetVacations()).Select(vacation => new VacationItemViewModel(vacation));
            Vacations = new ObservableCollection<VacationItemViewModel>(vacations);
        }

        private void NavigateToDetails(VacationItemViewModel param)
        {
            var parameters = new VacationDetailsParameters {Id = param.Id};

            _navigationService.NavigateToVacationDetails(this, parameters);
        }
    }
}
