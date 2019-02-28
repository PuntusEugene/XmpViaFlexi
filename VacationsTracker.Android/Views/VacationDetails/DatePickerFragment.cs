using System;
using Android.App;
using Android.OS;
using Android.Support.Annotation;
using Android.Widget;

namespace VacationsTracker.Android.Views.VacationDetails
{
    public class DatePickerFragment : DialogFragment,
        DatePickerDialog.IOnDateSetListener
    {
        private DateTime _currentDate;
        private Action<DateTime> _dateSelectedHandler;

        public static DatePickerFragment NewInstance([NonNull] DateTime currentDate, Action<DateTime> onDateSelected)
        {
            DatePickerFragment frag = new DatePickerFragment
            {
                _currentDate = currentDate,
                _dateSelectedHandler = onDateSelected
            };
            return frag;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            DateTime currently = _currentDate;
            DatePickerDialog dialog = new DatePickerDialog(Activity,
                this,
                currently.Year,
                currently.Month - 1,
                currently.Day);
            return dialog;
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
            _dateSelectedHandler?.Invoke(selectedDate);
        }
    }
}