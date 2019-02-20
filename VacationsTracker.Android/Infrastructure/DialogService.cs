using System;
using System.Diagnostics;
using VacationsTracker.Core.Infrastructure.Operations;

namespace VacationsTracker.Android.Infrastructure
{
    public class DialogService : IDialogService
    {
        public void ShowError(Exception error)
        {
            Debug.WriteLine(error.Message);
        }

        public void ShowNotification(string message)
        {
            Debug.WriteLine(message);
        }
    }
}