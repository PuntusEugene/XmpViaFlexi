﻿using System;
using VacationsTracker.Core.Domain.Interfaces;

namespace VacationsTracker.Core.Domain
{
    public class VacationModel : IDomainModel
    {
        public Guid Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public VacationType VacationType { get; set; }

        public VacationStatus VacationStatus { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public bool Validation()
        {
            return Start >= End 
                   && !string.IsNullOrWhiteSpace(CreatedBy) 
                   && Created > DateTime.MinValue;
        }
    }
}
