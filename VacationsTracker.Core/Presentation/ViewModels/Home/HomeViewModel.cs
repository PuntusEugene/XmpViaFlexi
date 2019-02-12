using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails;
using VacationsTracker.Core.Services.Interfaces;

namespace VacationsTracker.Core.Presentation.ViewModels.Home
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationService _vacationService;
        private ObservableCollection<VacationItemViewModel> _vacations;
        private bool _refreshing;

        public ObservableCollection<VacationItemViewModel> Vacations
        {
            get => _vacations;
            set => Set(ref _vacations, value);
        }

        public bool Refreshing
        {
            get => _refreshing;
            set => Set(ref _refreshing, value);
        }

        public ICommand<VacationItemViewModel> VacationSelectedCommand => CommandProvider.Get<VacationItemViewModel>(NavigateToDetails);

        public ICommand RefreshCommand => CommandProvider.GetForAsync(Refresh);

        public ICommand LogoutCommand => CommandProvider.Get(NavigateToLogin);

        public HomeViewModel(INavigationService navigationService, IVacationService vacationService)
        {
            _navigationService = navigationService;
            _vacationService = vacationService;
        }

        public async Task Refresh()
        {
            Refreshing = true;

            var vacations = (await _vacationService.GetVacations()).Select(vacation => new VacationItemViewModel(vacation));
            Vacations = new ObservableCollection<VacationItemViewModel>(vacations);

            Refreshing = false;
        }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            await Refresh();
        }

        private void NavigateToDetails(VacationItemViewModel param)
        {
            var parameters = new VacationDetailsParameters {Id = param?.Id ?? Guid.Empty};

            _navigationService.NavigateToVacationDetails(this, parameters);
        }

        private void NavigateToLogin()
        {
            _navigationService.NavigateToLogin(this);
        }
    }
}
