using System;
using FlexiMvvm;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Domain.Vacation;

namespace VacationsTracker.Core.Presentation.ViewModels.Home
{
    public class VacationItemViewModel : ViewModelBase
    {
        private Guid _id;

        private VacationStatus _vacationStatus;

        private VacationType _vacationType;

        private DateTime _dateBegin;

        private DateTime _dateEnd;

        //public  VacationItemViewModel(VacationModel)

        public Guid Id
        {
            get => _id;
            set => Set(ref _id, value);
        }

        public VacationStatus VacationStatus
        {
            get => _vacationStatus;
            set => Set(ref _vacationStatus, value);
        }

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
                RaisePropertyChanged(nameof(Duration));
            }
        }

        public DateTime DateEnd
        {
            get => _dateEnd;
            set
            {
                Set(ref _dateEnd, value);
                RaisePropertyChanged(nameof(Duration));
            } 
        }

        public ValueTuple<DateTime, DateTime> Duration
        {
            get => ValueTuple.Create(DateBegin, DateEnd);
        }

        public VacationItemViewModel() { }

        public VacationItemViewModel(VacationRequest vacationRequest)
        {
            Id = vacationRequest.Id;
            DateBegin = vacationRequest.Start;
            DateEnd = vacationRequest.End;
            VacationStatus = vacationRequest.VacationStatus;
            VacationType = vacationRequest.VacationType;
        }
    }
}
