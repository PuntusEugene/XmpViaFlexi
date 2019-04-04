using System;
using VacationsTracker.Core.Infrastructure.Operations;
using VacationsTracker.Core.Resourses;
using Debug = System.Diagnostics.Debug;

namespace VacationsTracker.Android.Infrastructure
{
    public class DialogService : IDialogService
    {
        public void ShowError(Exception error)
        {
            ShowAlert(Strings.ErrorTitleAlert, error.Message);
        }

        public void ShowNotification(string message)
        {
            ShowAlert(Strings.NotificationTitleAlert, message);
        }

        private void ShowAlert(string title, string message)
        {
            Debug.WriteLine($"{title}: {message}");

            //try
            //{
            //    var activity = (Application.Context as Activity);
            //    var contentView = activity?.FindViewById(Resource.Id.main_layout);

            //    var snackbar = Snackbar.Make(contentView, message, Snackbar.LengthLong);
            //    snackbar.Show();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}
        }
    }
}