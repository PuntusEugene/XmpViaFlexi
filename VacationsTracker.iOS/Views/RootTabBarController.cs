using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.iOS.Views.Home;
using VacationsTracker.iOS.Views.Setting;

namespace VacationsTracker.iOS.Views
{
    public class RootTabBarController : FlxTabBarController<EntryViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.View.BackgroundColor = UIColor.GroupTableViewBackgroundColor;

            var tab1 = new HomeViewController()
            {
                TabBarItem = new UITabBarItem(UITabBarSystemItem.Bookmarks, 0)
            };
            var tab2 = new SettingViewController
            {
                TabBarItem = new UITabBarItem(UITabBarSystemItem.Contacts, 1)
            };

            var navigatorController = new RootNavigationController()
            {
                ViewControllers = new UIViewController[] {tab1, tab2}
            };

            ViewControllers = new UIViewController[] { navigatorController };
        }
    }
}