using System;
using System.Collections.Generic;
using System.Text;
using FlexiMvvm;
using VacationsTracker.Core.Domain.Vacation;

namespace VacationsTracker.Core.Presentation.ViewModels.Vacation
{
    public class VacationCellViewModel : ViewModelBase
    {
        private VacationStatus _vacationStatus = VacationStatus.Approved;

        private VacationType _vacationType = VacationType.Regular;

        private DateTime _dateBegin = DateTime.Today;

        private DateTime _dateEnd = DateTime.Today;

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
            set => Set(ref _dateBegin, value);
        }

        public DateTime DateEnd
        {
            get => _dateEnd;
            set => Set(ref _dateEnd, value);
        }
    }
}
