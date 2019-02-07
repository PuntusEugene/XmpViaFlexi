using System;
using FlexiMvvm;

namespace VacationsTracker.Core.Presentation.ViewModels.Vacation.Parameters
{
    public class VacationDetailsParameters : ViewModelBundleBase
    {
        public string Id
        {
            get => Bundle.GetString(key: nameof(Id));
            set => Bundle.SetString(value, nameof(Id));
        }

        public Guid Guid => Guid.Parse(Id);
    }
}
