using System;

namespace VacationsTracker.Core.Infrastructure.Logger
{
    public interface IVacationLogger
    {
        void Info(string message);

        void Error(string message);

        void Error(Exception exception);
    }
}
