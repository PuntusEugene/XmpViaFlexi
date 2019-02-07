using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.iOS.Design;

namespace VacationsTracker.iOS.Views
{
    public class RootNavigationController : FlxNavigationController<EntryViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.View.BackgroundColor = AppColors.Primary;
        }
    }
}