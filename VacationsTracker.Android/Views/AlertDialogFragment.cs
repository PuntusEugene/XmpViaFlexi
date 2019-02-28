using Android.App;
using Android.OS;
using VacationsTracker.Core.Resourses;

namespace VacationsTracker.Android.Views
{
    internal class AlertDialogFragment : DialogFragment
    {
        public void ShowAlert()
        {
            var asd = new AlertDialogFragment();
            asd.Show(FragmentManager, string.Empty);
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var builder = new AlertDialog.Builder(Activity);
            builder
                .SetTitle("title")
                .SetMessage("text message")
                .SetPositiveButton(Strings.OkTitleButtonAlert, (sender, args) => { });
            return builder.Create();
        }
    }
}