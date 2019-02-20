using System;
using FlexiMvvm;

namespace VacationsTracker.Core.Presentation.ViewModels.VacationDetails
{
    public class VacationDetailsParameters : ViewModelBundleBase
    {
        public Guid Id
        {
            get => Guid.Parse(Bundle.GetString(key: nameof(Id)) ?? throw new InvalidOperationException());
            set => Bundle.SetString(value.ToString(), nameof(Id));
        }
    }
}
