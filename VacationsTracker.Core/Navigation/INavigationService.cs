using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Core.Presentation.ViewModels.Vacation;
using VacationsTracker.Core.Presentation.ViewModels.Vacation.Parameters;

namespace VacationsTracker.Core.Navigation
{
    public interface INavigationService
    {
        void NavigateToLogin(EntryViewModel fromViewModel);

        void NavigateToHome(LoginViewModel fromViewModel);

        void NavigateToVacationDetails(HomeViewModel fromViewModel, VacationDetailsParameters parameters);

        void NavigateBackToHome(VacationDetailsViewModel fromViewModel);

        void NavigateToNewVacation(HomeViewModel fromViewModel);

        void NavigateBackToHome(NewVacationViewModel fromViewModel);
    }
}
