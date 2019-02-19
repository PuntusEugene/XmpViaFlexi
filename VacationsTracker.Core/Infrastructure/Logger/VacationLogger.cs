using System;
using System.Diagnostics;

namespace VacationsTracker.Core.Infrastructure.Logger
{
    public class VacationLogger : IVacationLogger
    {
        public void Error(string message)
        {
            Debug.WriteLine(message);
        }

        public void Error(Exception exception)
        {
            Debug.WriteLine(exception.Message);
        }

        public void Info(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
