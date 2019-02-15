using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using FlexiMvvm.Operations;
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

        public LoginViewModel(INavigationService navigationService, IIdentityRepository identityRepository, IOperationFactory operationFactory) : base(operationFactory)
        {
            _navigationService = navigationService;
            _identityRepository = identityRepository;
        }

        private async Task Login()
        {
            var userCredentialModel = new UserCredentialModel(Username, Password);
            ValidCredentials = userCredentialModel.Validation();

            if(!ValidCredentials)
                return;

            await OperationFactory.CreateOperation(OperationContext)
                .WithExpressionAsync(cancellation => _identityRepository.AuthenticationAsync(userCredentialModel, cancellation))
                .OnSuccess(isSuccess =>
                {
                    if (isSuccess)
                    {
                        _navigationService.NavigateToHome(this);
                    }
                    else
                    {
                        ValidCredentials = false;
                    }
                })
                .OnError<Exception>(error =>
                {
                    Debug.WriteLine(error.Exception);
                    ValidCredentials = false;
                })
                .ExecuteAsync();
        }

    }
}
