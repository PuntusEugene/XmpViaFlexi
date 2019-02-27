using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Collections;
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
        private bool _loading;
        private DateTime _lastUpdateTime;

        public RangeObservableCollection<VacationItemViewModel> Vacations { get; } = new RangeObservableCollection<VacationItemViewModel>();

        public bool Loading
        {
            get => _loading;
            set => Set(ref _loading, value);
        }

        public DateTime LastUpdateTime
        {
            get => _lastUpdateTime;
            set => Set(ref _lastUpdateTime, value);
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

        private async Task Refresh()
        {
            await OperationFactory
                .CreateOperation(OperationContext)
                .WithLoadingNotification()
                .WithInternetConnectionCondition()
                .WithExpressionAsync(cancellation => _vacationRepository.GetVacationsAsync(cancellation))
                .OnSuccess(vacationModels =>  
                    {
                        Vacations.Clear();
                        var vacations = vacationModels.Select(vacation => new VacationItemViewModel(vacation));
                        Vacations.AddRange(vacations);
                        Vacations.AddRange(vacations);
                        Vacations.AddRange(vacations);

                        LastUpdateTime = DateTime.Now;
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
