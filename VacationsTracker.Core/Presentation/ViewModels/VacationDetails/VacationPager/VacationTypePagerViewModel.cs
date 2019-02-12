using FlexiMvvm;
using VacationsTracker.Core.Domain.Vacation;

namespace VacationsTracker.Core.Presentation.ViewModels.VacationDetails.VacationPager
{
    public class VacationTypePagerViewModel : ViewModelBase<VacationTypePagerParameters>
    {
        public VacationType VacationType { get; private set; }

        protected override void Initialize(VacationTypePagerParameters parameters)
        {
            base.Initialize(parameters);

            VacationType = parameters.NotNull().VacationType;
        }
    }
}
