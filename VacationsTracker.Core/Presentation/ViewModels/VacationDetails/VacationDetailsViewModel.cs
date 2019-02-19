using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using FlexiMvvm.Operations;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Domain.Exceptions;
using VacationsTracker.Core.Infrastructure.Operations;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails.VacationPager;
using VacationsTracker.Core.Repositories.Interfaces;
using VacationsTracker.Core.Resourses;

namespace VacationsTracker.Core.Presentation.ViewModels.VacationDetails
{
    public class VacationDetailsViewModel : ViewModelBase<VacationDetailsParameters>, IViewModelWithOperation
    {
        private readonly INavigationService _navigationService;
        private readonly IVacationRepository _vacationRepository;
        private readonly IDialogService _dialogService;
        private Guid _id;
        private VacationType _vacationType;
        private DateTime _dateBegin;
        private DateTime _dateEnd;
        private VacationStatus _vacationStatus;
        private bool _loading;
        
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

        public bool Loading
        {
            get => _loading;
            set => Set(ref _loading, value);
        }

        public ObservableCollection<VacationTypePagerParameters> VacationTypes { get; }

        public ICommand BackToHomeCommand => CommandProvider.Get(BackToHome);

        public ICommand SaveVacationCommand => CommandProvider.GetForAsync(SaveVacation);

        public VacationDetailsViewModel(INavigationService navigationService, IVacationRepository vacationRepository, IDialogService dialogService, IOperationFactory operationFactory) : base(operationFactory)
        {
            _navigationService = navigationService;
            _vacationRepository = vacationRepository;
            _dialogService = dialogService;

            VacationTypes = new ObservableCollection<VacationTypePagerParameters>(
                Enum.GetValues(typeof(VacationType))
                    .Cast<VacationType>().Select(t => new VacationTypePagerParameters(t)));
        }

        protected override async Task InitializeAsync(VacationDetailsParameters parameters)
        {
            await base.InitializeAsync(parameters);

            await OperationFactory
                .CreateOperation(OperationContext)
                .WithLoadingNotification()
                .WithInternetConnectionCondition()
                .WithExpressionAsync((cancellation) =>
                {
                    if (parameters != null && parameters.Id != Guid.Empty)
                    {
                        return _vacationRepository.GetVacationByIdAsync(parameters.Id, cancellation);
                    }

                    return Task.Run(() => new VacationModel()
                    {
                        VacationStatus = VacationStatus.Approved,
                        VacationType = VacationType.Undefined,
                        Start = DateTime.Today,
                        End = DateTime.Today
                    }, cancellation);
                })
                .OnSuccess(vacation =>
                {
                    _id = vacation.Id;
                    VacationStatus = vacation.VacationStatus;
                    VacationType = vacation.VacationType;
                    DateBegin = vacation.Start;
                    DateEnd = vacation.End;
                })
                .OnError<InternetConnectionException>(ShowError)
                .OnError<AuthorizationException>(ShowError)
                .OnError<WebException>(ShowError)
                .OnError<Exception>(ShowError)
                .ExecuteAsync();
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
                CreatedBy = Strings.CreatedBy,
                Created = DateTime.Now,
            };

            await OperationFactory
                .CreateOperation(OperationContext)
                .WithLoadingNotification()
                .WithInternetConnectionCondition()
                .WithExpressionAsync((cancellation) => _vacationRepository.CreateOrUpdateVacationAsync(vacationModel, cancellation))
                .OnSuccess(vacationModels => BackToHome())
                .OnError<InternetConnectionException>(ShowError)
                .OnError<AuthorizationException>(ShowError)
                .OnError<WebException>(ShowError)
                .OnError<Exception>(ShowError)
                .ExecuteAsync();
        }

        private void ShowError<T>(OperationError<T> error) where T : Exception
        {
            _dialogService.ShowError(error.Exception);
        }
    }

}
