using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using FlexiMvvm.Operations;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails;
using VacationsTracker.Core.Repositories.Interfaces;

namespace VacationsTracker.Core.Presentation.ViewModels.Home
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationRepository _vacationRepository;
        private readonly IIdentityRepository _identityRepository;
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

        public ICommand LogoutCommand => CommandProvider.GetForAsync(NavigateToLogin);

        public HomeViewModel(INavigationService navigationService, IVacationRepository vacationRepository, IIdentityRepository identityRepository, IOperationFactory operationFactory) : base(operationFactory)
        {
            _navigationService = navigationService;
            _vacationRepository = vacationRepository;
            _identityRepository = identityRepository;
        }

        public async Task Refresh()
        {
            Refreshing = true;

            await OperationFactory.CreateOperation(OperationContext)
                .WithExpressionAsync(cancellation => _vacationRepository.GetVacationsAsync())
                .OnSuccess(vacationModels =>  
                    {
                        var vacations = vacationModels.Select(vacation => new VacationItemViewModel(vacation));
                        Vacations = new ObservableCollection<VacationItemViewModel>(vacations);
                    })
                .OnError<AuthenticationException>(error => Debug.WriteLine(error.Exception))
                .OnError<WebException>(error => Debug.WriteLine(error.Exception.Message))
                .OnError<Exception>(error =>  Debug.WriteLine(error.Exception.Message))
                .ExecuteAsync();

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

        private async Task NavigateToLogin()
        {
            await OperationFactory.CreateOperation(OperationContext)
                .WithExpression(_identityRepository.Logout)
                .OnSuccess(isSuccess => 
                {
                    if (isSuccess)
                    {
                        _navigationService.NavigateToLogin(this);
                    }
                })
                .OnError<Exception>(error => Debug.WriteLine(error))
                .ExecuteAsync();
        }
    }
}
