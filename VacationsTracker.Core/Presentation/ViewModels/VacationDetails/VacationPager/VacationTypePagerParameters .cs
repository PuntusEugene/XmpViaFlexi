using FlexiMvvm;
using VacationsTracker.Core.Domain.Vacation;

namespace VacationsTracker.Core.Presentation.ViewModels.VacationDetails.VacationPager
{
    public class VacationTypePagerParameters : ViewModelBundleBase
    {
        public VacationTypePagerParameters(VacationType type)
        {
            VacationType = type;
        }

        public VacationType VacationType
        {
            get => (VacationType)Bundle.GetInt();
            set => Bundle.SetInt((int)value);
        }
    }
}
