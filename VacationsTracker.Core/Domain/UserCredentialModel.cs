using System;
using System.Collections.Generic;
using System.Text;

namespace VacationsTracker.Core.Domain
{
    public class UserCredentialModel
    {
        public UserCredentialModel(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; private set; }

        public string Password { get; private set; }
    }
}
