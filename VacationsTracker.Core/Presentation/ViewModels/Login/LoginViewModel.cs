using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Repositories.Interfaces;

namespace VacationsTracker.Core.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username = "ark";
        private string _password = "123";
        private bool _validCredentials = true;
        private readonly IIdentityRepository _identityRepository;
        private readonly INavigationService _navigationService;

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

        public LoginViewModel(INavigationService navigationService, IIdentityRepository identityRepository)
        {
            _navigationService = navigationService;
            _identityRepository = identityRepository;
        }

        private async Task Login()
        {
            ValidCredentials = await _identityRepository.AuthorizationAsync(new UserCredentialModel(Username, Password));

            if (ValidCredentials)
            {
                //await OperationFactory.CreateOperation(OperationContext)
                //    .WithExpressionAsync(cancelation => _identityRepository.AuthorizationAsync(Username, Password))
                //    .OnSuccess((isSuccsess) =>
                //    {
                //        if (isSuccsess)
                //        {
                //            _navigationService.NavigateToHome(this);
                //        }
                //    })
                //    .ExecuteAsync();

                _navigationService.NavigateToHome(this);
            }
        }

    }
}
