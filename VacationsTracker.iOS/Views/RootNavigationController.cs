using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.iOS.Design;
using VacationsTracker.iOS.Views.Login;
using VacationsTracker.iOS.Views.Setting;

namespace VacationsTracker.iOS.Views
{
    public class RootNavigationController : FlxNavigationController<EntryViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.View.BackgroundColor = UIColor.GroupTableViewBackgroundColor;
        }
    }
}