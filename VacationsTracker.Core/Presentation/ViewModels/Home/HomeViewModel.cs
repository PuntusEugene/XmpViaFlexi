using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using FlexiMvvm.Operations;
using VacationsTracker.Core.Domain.Exceptions;
using VacationsTracker.Core.Infrastructure.Operations;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails;
using VacationsTracker.Core.Repositories.Interfaces;

namespace VacationsTracker.Core.Presentation.ViewModels.Home
{
    public class HomeViewModel : ViewModelBase, IViewModelWithOperation
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationRepository _vacationRepository;
        private readonly IIdentityRepository _identityRepository;
        private readonly IDialogService _dialogService;
        private ObservableCollection<VacationItemViewModel> _vacations;
        private bool _loading;

        public ObservableCollection<VacationItemViewModel> Vacations
        {
            get => _vacations;
            set => Set(ref _vacations, value);
        }

        public bool Loading
        {
            get => _loading;
            set => Set(ref _loading, value);
        }

        public ICommand<VacationItemViewModel> VacationSelectedCommand => CommandProvider.Get<VacationItemViewModel>(NavigateToDetails);

        public ICommand RefreshCommand => CommandProvider.GetForAsync(Refresh);

        public ICommand LogoutCommand => CommandProvider.GetForAsync(NavigateToLogin);

        public HomeViewModel(INavigationService navigationService, IVacationRepository vacationRepository, IIdentityRepository identityRepository, IDialogService dialogService, IOperationFactory operationFactory) : base(operationFactory)
        {
            _navigationService = navigationService;
            _vacationRepository = vacationRepository;
            _identityRepository = identityRepository;
            _dialogService = dialogService;
        }

        public async Task Refresh()
        {
            await OperationFactory
                .CreateOperation(OperationContext)
                .WithLoadingNotification()
                .WithInternetConnectionCondition()
                .WithExpressionAsync(cancellation => _vacationRepository.GetVacationsAsync(cancellation))
                .OnSuccess(vacationModels =>  
                    {
                        var vacations = vacationModels.Select(vacation => new VacationItemViewModel(vacation));
                        Vacations = new ObservableCollection<VacationItemViewModel>(vacations);
                    })
                .OnError<AuthorizationException>(error => _dialogService.ShowError(error.Exception))
                .OnError<WebException>(error => _dialogService.ShowError(error.Exception))
                .OnError<Exception>(error => _dialogService.ShowError(error.Exception))
                .ExecuteAsync();
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
            await OperationFactory
                .CreateOperation(OperationContext)
                .WithLoadingNotification()
                .WithInternetConnectionCondition()
                .WithExpression(_identityRepository.Logout)
                .OnSuccess(() => _navigationService.NavigateToLogin(this))
                .OnError<Exception>(error => _dialogService.ShowError(error.Exception))
                .ExecuteAsync();
        }
    }
}
