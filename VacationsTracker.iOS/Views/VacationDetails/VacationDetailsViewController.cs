using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Presentation.ViewModels.Vacation;
using VacationsTracker.Core.Presentation.ViewModels.Vacation.Parameters;

namespace VacationsTracker.iOS.Views.VacationDetails
{
    internal class VacationDetailsViewController : FlxBindableViewController<VacationDetailsViewModel, VacationDetailsParameters>
    {
        public new VacationDetailsView View
        {
            get => (VacationDetailsView) base.View.NotNull();
            set => base.View = value;
        }

        public VacationDetailsViewController(VacationDetailsParameters parameters) : base(parameters)
        {
        }

        public override void LoadView()
        {
            View = new VacationDetailsView();

            NavigationItem.LeftBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Cancel);
        }

        public override void Bind(BindingSet<VacationDetailsViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(NavigationItem.LeftBarButtonItem)
                .For(v => v.ClickedBinding())
                .To(vm => vm.BackToHomeCommand);
        }
    }
}