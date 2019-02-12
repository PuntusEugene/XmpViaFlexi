using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails.VacationPager;
using VacationsTracker.iOS.ValueConverters;

namespace VacationsTracker.iOS.Views.VacationDetails.VacationsPager
{
    internal class VacationTypePagerViewController
        : FlxBindableViewController<VacationTypePagerViewModel, VacationTypePagerParameters>
    {
        public new VacationTypePagerView View
        {
            get => (VacationTypePagerView)base.View.NotNull();
            set => base.View = value;
        }

        public VacationTypePagerViewController(VacationTypePagerParameters parameters) : base(parameters)
        {
        }

        public override void LoadView()
        {
            View = new VacationTypePagerView();
        }

        public override void Bind(BindingSet<VacationTypePagerViewModel> bindingSet)
        {
            base.Bind(bindingSet);
            
            bindingSet.Bind(View.VacationTypeImageView)
                .For(v => v.Image)
                .To(vm => vm.VacationType)
                .WithConvertion<VacationTypeToImageValueConverter>();

            bindingSet.Bind(View.VacationTypeLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.VacationType)
                .WithConvertion<VacationTypeToStringValueConverter>();
        }
    }
}