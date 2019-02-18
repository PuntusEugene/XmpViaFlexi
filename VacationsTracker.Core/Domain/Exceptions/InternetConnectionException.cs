using System;

namespace VacationsTracker.Core.Domain.Exceptions
{
    public class InternetConnectionException : Exception
    {
        public InternetConnectionException(string message) : base(message)
        {
        }
    }
}
