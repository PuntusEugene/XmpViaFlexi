using System.Diagnostics;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Services.Interfaces;

namespace VacationsTracker.Core.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IIdentityService _identityService;
        private readonly INavigationService _navigationService;
        private bool _validCredentials = true;
        private string _username;
        private string _password;
        
        public LoginViewModel(INavigationService navigationService, IIdentityService identityService)
        {
            _navigationService = navigationService;
            _identityService = identityService;
        }

        public string Username
        {
            get => _username;
            set => Set(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public bool ValidCredentials
        {
            get => _validCredentials;
            private set => Set(ref _validCredentials, value);
        }

        public ICommand LoginCommand => CommandProvider.GetForAsync(Login);

        private async Task Login()
        {
            // TODO login operation

            ValidCredentials = await _identityService.AuthorizationAsync(Username, Password);

            if (ValidCredentials)
            {
                _navigationService.NavigateToHome(this);
            }
        }

    }
}
