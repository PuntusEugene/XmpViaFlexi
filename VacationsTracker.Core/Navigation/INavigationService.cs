﻿using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails.Parameters;

namespace VacationsTracker.Core.Navigation
{
    public interface INavigationService
    {
        void NavigateToLogin(EntryViewModel fromViewModel);

        void NavigateToHome(LoginViewModel fromViewModel);

        void NavigateToVacationDetails(HomeViewModel fromViewModel, VacationDetailsParameters parameters);

        void NavigateBackToHome(VacationDetailsViewModel fromViewModel);
    }
}
