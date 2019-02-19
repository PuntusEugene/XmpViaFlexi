using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.iOS.ValueConverters
{
    internal class VacationStatusToSegmentValueConverter : ValueConverter<VacationStatus, nint>
    {
        protected override ConversionResult<nint> Convert(VacationStatus value, Type targetType, object parameter, CultureInfo culture)
        {
            nint index = 0;

            switch (value)
            {
                case VacationStatus.Approved:
                    index = 0;
                    break;

                case VacationStatus.Closed:
                    index = 1;
                    break;
            }

            return ConversionResult<nint>.SetValue(index);
        }

        protected override ConversionResult<VacationStatus> ConvertBack(nint value, Type targetType, object parameter, CultureInfo culture)
        {
            VacationStatus status = VacationStatus.Approved;

            switch (value)
            {
                case 0:
                    status = VacationStatus.Approved;
                    break;

                case 1:
                    status = VacationStatus.Closed;
                    break;
            }

            return ConversionResult<VacationStatus>.SetValue(status);
        }
    }
}