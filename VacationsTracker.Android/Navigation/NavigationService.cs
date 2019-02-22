using Android.Content;
using FlexiMvvm;
using FlexiMvvm.Navigation;
using VacationsTracker.Android.Views;
using VacationsTracker.Android.Views.Home;
using VacationsTracker.Android.Views.Login;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails;

namespace VacationsTracker.Android.Navigation
{
    public class NavigationService : NavigationServiceBase, INavigationService
    {
        public void NavigateToLogin(EntryViewModel fromViewModel)
        {
            var splashScreenActivity = GetActivity<EntryViewModel, SplashScreenActivity>(fromViewModel);
            var loginIntent = new Intent(splashScreenActivity, typeof(LoginActivity));
            splashScreenActivity.NotNull().StartActivity(loginIntent);
        }

        public void NavigateBackToHome(VacationDetailsViewModel fromViewModel)
        {
            throw new System.NotImplementedException();
        }

        public void NavigateToHome(LoginViewModel fromViewModel)
        {
            var loginActivity = GetActivity<LoginViewModel, LoginActivity>(fromViewModel);
            var homeIntent = new Intent(loginActivity, typeof(HomeActivity));
            homeIntent.AddFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            loginActivity.NotNull().StartActivity(homeIntent);
        }

        public void NavigateToVacationDetails(HomeViewModel fromViewModel, VacationDetailsParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public void NavigateToLogin(HomeViewModel fromViewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}