using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.iOS.Views
{
    public class RootNavigationController : FlxNavigationController<EntryViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.GroupTableViewBackgroundColor;
        }
    }
}