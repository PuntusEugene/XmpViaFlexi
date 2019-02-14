using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexiMvvm;
using FlexiMvvm.Navigation;
using Foundation;
using UIKit;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails;
using VacationsTracker.iOS.Views;
using VacationsTracker.iOS.Views.Home;
using VacationsTracker.iOS.Views.Login;
using VacationsTracker.iOS.Views.Setting;
using VacationsTracker.iOS.Views.VacationDetails;

namespace VacationsTracker.iOS.Navigation
{
    public class NavigationTabBarService : NavigationServiceBase, INavigationService
    {
        public void NavigateToLogin(EntryViewModel fromViewModel)
        {
            var navigationController = new RootNavigationController
            {
                ViewControllers = new UIViewController[] { new LoginViewController() }
            };

            var rootViewController = GetViewController<EntryViewModel, RootTabBarController>(fromViewModel);
            rootViewController.NotNull().AddChildViewController(navigationController);
        }

        public void NavigateToLogin(HomeViewModel fromViewModel)
        {
            var loginViewController = GetViewController<HomeViewModel, HomeViewController>(fromViewModel);
            loginViewController.NotNull().NavigationController.SetViewControllers(
                new UIViewController[] { new LoginViewController() },
                true);
        }

        public void NavigateToHome(LoginViewModel fromViewModel)
        {
            var loginViewController = GetViewController<LoginViewModel, LoginViewController>(fromViewModel);
            
            var navigationController = new RootNavigationController
            {
                ViewControllers = new UIViewController[] { new HomeViewController(), new SettingViewController() }
            };

            loginViewController.NotNull().NavigationController.SetViewControllers(
                new UIViewController[] { navigationController },
                true);
        }

        public void NavigateToVacationDetails(HomeViewModel fromViewModel, VacationDetailsParameters parameters)
        {
            var homeViewController = GetViewController<HomeViewModel, HomeViewController>(fromViewModel);
            homeViewController.NotNull().NavigationController.PushViewController(new VacationDetailsViewController(parameters), true);
        }

        public void NavigateBackToHome(VacationDetailsViewModel fromViewModel)
        {
            var vacationDetailsViewController = GetViewController<VacationDetailsViewModel, VacationDetailsViewController>(fromViewModel);
            vacationDetailsViewController.NotNull().NavigationController.PopViewController(true);
        }
    }
}