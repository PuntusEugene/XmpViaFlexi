using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Android.ValueConverters
{
    public class VacationStatusToRadioButtonIdValueConverter : ValueConverter<VacationStatus, int>
    {
        protected override ConversionResult<int> Convert(VacationStatus value, Type targetType, object parameter, CultureInfo culture)
        {
            int resourseId = -1;

            switch (value)
            {
                case VacationStatus.Approved:
                    resourseId = Resource.Id.approved_radio;
                    break;

                case VacationStatus.Closed:
                    resourseId = Resource.Id.closed_radio;
                    break;
            }

            return ConversionResult<int>.SetValue(resourseId);
        }

        protected override ConversionResult<VacationStatus> ConvertBack(int value, Type targetType, object parameter, CultureInfo culture)
        {
            var vacationStatus = VacationStatus.Approved;

            switch (value)
            {
                case Resource.Id.approved_radio:
                    vacationStatus = VacationStatus.Approved;
                    break;

                case Resource.Id.closed_radio:
                    vacationStatus = VacationStatus.Closed;
                    break;
            }

            return ConversionResult<VacationStatus>.SetValue(vacationStatus);
        }
    }
}