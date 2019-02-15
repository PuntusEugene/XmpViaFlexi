using VacationsTracker.Core.Domain.Interfaces;

namespace VacationsTracker.Core.Domain
{
    public class UserCredentialModel : IValidation
    {
        public UserCredentialModel(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; private set; }

        public string Password { get; private set; }

        public bool Validation()
        {
            return !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(Password);
        }
    }
}
