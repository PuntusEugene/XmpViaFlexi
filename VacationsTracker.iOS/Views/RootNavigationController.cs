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
            this.View.BackgroundColor = UIColor.GroupTableViewBackgroundColor;
        }
    }
}