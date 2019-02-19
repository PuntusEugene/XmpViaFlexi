using System;

namespace VacationsTracker.Core.Domain.Exceptions
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException(string message) : base(message)
        {

        }
    }
}
