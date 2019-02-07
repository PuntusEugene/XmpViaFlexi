using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using VacationsTracker.Core.Domain.Vacation;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.Vacation;
using VacationsTracker.Core.Presentation.ViewModels.Vacation.Parameters;
using VacationsTracker.Core.Services.Interfaces;

namespace VacationsTracker.Core.Presentation.ViewModels.Home
{
    public class HomeViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IVacationService _vacationService;
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

        protected async override Task InitializeAsync()
        {
            await base.InitializeAsync();

            Vacations = new ObservableCollection<VacationItemViewModel>();

            var vacations = await _vacationService.GetVacations();
            
            foreach (var vacation in vacations.Result)
            {
                Vacations.Add(new VacationItemViewModel(vacation));
            }
        }

        private void NavigateToDetails(VacationItemViewModel param)
        {
            var parameters = param == null
                ? null
                : new VacationDetailsParameters {Id = param.Id.ToString()};

            _navigationService.NavigateToVacationDetails(this, parameters);
        }
    }
}
