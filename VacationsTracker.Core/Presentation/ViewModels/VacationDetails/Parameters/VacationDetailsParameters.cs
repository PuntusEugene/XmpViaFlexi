using System;
using FlexiMvvm;

namespace VacationsTracker.Core.Presentation.ViewModels.VacationDetails.Parameters
{
    public class VacationDetailsParameters : ViewModelBundleBase
    {
        public Guid Id
        {
            get => Guid.Parse(Bundle.GetString(key: nameof(Id)));
            set => Bundle.SetString(value.ToString(), nameof(Id));
        }
    }
}
