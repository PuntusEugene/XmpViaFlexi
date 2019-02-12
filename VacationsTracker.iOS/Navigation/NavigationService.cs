using FlexiMvvm;
using FlexiMvvm.Navigation;
using UIKit;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails;
using VacationsTracker.iOS.Views;
using VacationsTracker.iOS.Views.Home;
using VacationsTracker.iOS.Views.Login;
using VacationsTracker.iOS.Views.VacationDetails;

namespace VacationsTracker.iOS.Navigation
{
    public class NavigationService : NavigationServiceBase, INavigationService
    {
        public void NavigateToLogin(EntryViewModel fromViewModel)
        {
            var rootViewController = GetViewController<EntryViewModel, RootNavigationController>(fromViewModel);
            rootViewController.NotNull().PushViewController(new LoginViewController(), false);
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
            loginViewController.NotNull().NavigationController.SetViewControllers(
                new UIViewController[] { new HomeViewController() },
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