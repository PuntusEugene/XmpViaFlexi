using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Threading;
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

namespace VacationsTracker.Core.Presentation.ViewModels.VacationDetails
{
    public class VacationDetailsViewModel : ViewModelBase<VacationDetailsParameters>, IViewModelWithOperation
    {
        private Guid _id;
        private VacationType _vacationType;
        private DateTime _dateBegin;
        private DateTime _dateEnd;
        private VacationStatus _vacationStatus;
        private bool _loading;
        private readonly INavigationService _navigationService;
        private readonly IVacationRepository _vacationRepository;
        
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

        public VacationDetailsViewModel(INavigationService navigationService, IVacationRepository vacationRepository, IOperationFactory operationFactory) : base(operationFactory)
        {
            _navigationService = navigationService;
            _vacationRepository = vacationRepository;

            VacationTypes = new ObservableCollection<VacationTypePagerParameters>(
                Enum.GetValues(typeof(VacationType))
                    .Cast<VacationType>().Select(t => new VacationTypePagerParameters(t)));
        }

        protected override async Task InitializeAsync(VacationDetailsParameters parameters)
        {
            await base.InitializeAsync(parameters);

            var vacation = parameters != null && parameters.Id != Guid.Empty ? await _vacationRepository.GetVacationByIdAsync(parameters.Id, CancellationToken.None)
                : new VacationModel()
                {
                    VacationStatus = VacationStatus.Approved,
                    VacationType = VacationType.Undefined,
                    Start = DateTime.Today,
                    End = DateTime.Today
                };

            _id = vacation.Id;
            VacationType = vacation.VacationType;
            DateBegin = vacation.Start;
            DateEnd = vacation.End;
            VacationStatus = vacation.VacationStatus;
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
            
            await OperationFactory
                .CreateOperation(OperationContext)
                .WithLoadingNotification()
                .WithInternetConnectionCondition()
                .WithExpressionAsync((cancellation) => _vacationRepository.CreateOrUpdateVacationAsync(vacationModel, cancellation))
                .OnSuccess(vacationModels => BackToHome())
                .OnError<InternetConnectionException>(error => Debug.WriteLine(error))
                .OnError<AuthenticationException>(error => Debug.WriteLine(error))
                .OnError<WebException>(error => Debug.WriteLine(error))
                .OnError<Exception>(error => Debug.WriteLine(error))
                .ExecuteAsync();
        }
    }

}
