using System;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using FlexiMvvm.Operations;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Domain.Exceptions;
using VacationsTracker.Core.Infrastructure.Operations;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Repositories.Interfaces;
using VacationsTracker.Core.Resourses;

namespace VacationsTracker.Core.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase, IViewModelWithOperation
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private string _username = "ark";
        private string _password = "123";
        private bool _validCredentials = true;
        private bool _loading;
        private string _loginEmptyError;
        private string _passwordEmptyError;

        public string Username
        {
            get => _username;
            set
            {
                Set(ref _username, value);
                LoginEmptyError = string.Empty;
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                Set(ref _password, value);
                PasswordEmptyError = string.Empty;
            }
        }

        public bool ValidCredentials
        {
            get => _validCredentials;
            private set => Set(ref _validCredentials, value);
        }

        public bool Loading
        {
            get => _loading;
            set => Set(ref _loading, value);
        }

        public string LoginEmptyError
        {
            get => _loginEmptyError;
            set => Set(ref _loginEmptyError, value);
        }

        public string PasswordEmptyError
        {
            get => _passwordEmptyError;
            set => Set(ref _passwordEmptyError, value);
        }
        

        public ICommand LoginCommand => CommandProvider.GetForAsync(Login);

        public LoginViewModel(INavigationService navigationService, IIdentityRepository identityRepository, IDialogService dialogService, IOperationFactory operationFactory) : base(operationFactory)
        {
            _navigationService = navigationService;
            _identityRepository = identityRepository;
            _dialogService = dialogService;
        }

        private async Task Login()
        {
            var userCredentialModel = new UserCredentialModel(Username, Password);

            if (!userCredentialModel.Validation())
            {
                if (string.IsNullOrWhiteSpace(userCredentialModel.Login))
                {
                    LoginEmptyError = Strings.LoginIsEmpty;
                }

                if (string.IsNullOrWhiteSpace(userCredentialModel.Password))
                {
                    PasswordEmptyError = Strings.PasswordIsEmpty;
                }
                return;
            }

            await OperationFactory
                .CreateOperation(OperationContext)
                .WithLoadingNotification()
                .WithInternetConnectionCondition()
                .WithExpressionAsync(cancellation => _identityRepository.LoginAsync(userCredentialModel, cancellation))
                .OnSuccess(() => _navigationService.NavigateToHome(this))
                .OnError<InternetConnectionException>(LoginNotifyException)
                .OnError<AuthenticationException>(LoginNotifyException)
                .OnError<WebException>(LoginNotifyException)
                .OnError<Exception>(LoginNotifyException)
                .OnError<Exception>(LoginNotifyException)
                .ExecuteAsync();
        }

        private void LoginNotifyException<T>(OperationError<T> error)  where T : Exception
        {
            _dialogService.ShowError(error.Exception);
            ValidCredentials = false;
        }
    }
}
