using System;
using UIKit;
using VacationsTracker.Core.Infrastructure.Logger;
using VacationsTracker.Core.Infrastructure.Operations;
using VacationsTracker.Core.Resourses;

namespace VacationsTracker.iOS.Infrastructure
{
    internal class DialogService : IDialogService
    {
        private readonly IVacationLogger _logger;

        public DialogService(IVacationLogger logger)
        {
            _logger = logger;
        }

        public void ShowError(Exception error)
        {
            _logger.Error(error);

            ShowAlert(Strings.ErrorTitleAlert, error.Message);
        }

        public void ShowNotification(string message)
        {
            _logger.Info(message);

            ShowAlert(Strings.NotificationTitleAlert, message);
        }

        private void ShowAlert(string title, string message)
        {
            var okAlertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            okAlertController.AddAction(UIAlertAction.Create(Strings.OkTitleButtonAlert, UIAlertActionStyle.Default, null));

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(okAlertController,
                true, null);
        }
    }
}