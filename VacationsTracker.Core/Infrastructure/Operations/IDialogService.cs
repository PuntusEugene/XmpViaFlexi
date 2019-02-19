using System;

namespace VacationsTracker.Core.Infrastructure.Operations
{
    public interface IDialogService
    {
        void ShowError(Exception error);

        void ShowNotification(string message);
    }
}