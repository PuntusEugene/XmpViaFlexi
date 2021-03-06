﻿using Android.Content;
using FlexiMvvm;
using FlexiMvvm.Navigation;
using FlexiMvvm.Views;
using VacationsTracker.Android.Views;
using VacationsTracker.Android.Views.Home;
using VacationsTracker.Android.Views.Login;
using VacationsTracker.Android.Views.VacationDetails;
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
            var detailActivity = GetActivity<VacationDetailsViewModel, VacationDetailActivity>(fromViewModel);
            detailActivity.NotNull().Finish();
        }

        public void NavigateToHome(LoginViewModel fromViewModel)
        {
            var loginActivity = GetActivity<LoginViewModel, LoginActivity>(fromViewModel);
            var homeIntent = new Intent(loginActivity, typeof(HomeActivity));
            homeIntent.AddFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask | ActivityFlags.ClearTop);
            loginActivity.NotNull().StartActivity(homeIntent);
        }

        public void NavigateToVacationDetails(HomeViewModel fromViewModel, VacationDetailsParameters parameters)
        {
            var homeActivity = GetActivity<HomeViewModel, HomeActivity>(fromViewModel);
            var detailIntent = new Intent(homeActivity, typeof(VacationDetailActivity));
            detailIntent.PutViewModelParameters(parameters);
            homeActivity.NotNull().StartActivity(detailIntent);
        }

        public void NavigateToLogin(HomeViewModel fromViewModel)
        {
            var homeActivity = GetActivity<HomeViewModel, HomeActivity>(fromViewModel);
            var loginIntent = new Intent(homeActivity, typeof(LoginActivity));
            loginIntent.AddFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask | ActivityFlags.ClearTop);
            homeActivity.NotNull().StartActivity(loginIntent);
        }
    }
}