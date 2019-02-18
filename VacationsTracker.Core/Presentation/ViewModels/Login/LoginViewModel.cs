using System;
using System.Diagnostics;
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

namespace VacationsTracker.Core.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase, IViewModelWithOperation
    {
        private string _username = "ark";
        private string _password = "123";
        private bool _validCredentials = true;
        private bool _loading;
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

        public bool Loading
        {
            get => _loading;
            set => Set(ref _loading, value);
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

            await OperationFactory
                .CreateOperation(OperationContext)
                .WithLoadingNotification()
                .WithInternetConnectionCondition()
                .WithExpressionAsync(cancellation => _identityRepository.AuthenticationAsync(userCredentialModel, cancellation))
                .OnSuccess(() => _navigationService.NavigateToHome(this))
                .OnError<InternetConnectionException>(LoginNotifyException)
                .OnError<AuthenticationException>(LoginNotifyException)
                .OnError<WebException>(LoginNotifyException)
                .OnError<Exception>(LoginNotifyException)
                .ExecuteAsync();
        }

        private void LoginNotifyException<T>(OperationError<T> error)  where T : Exception
        {
            Debug.WriteLine(error.Exception.Message);
            ValidCredentials = false;
        }
    }
}
