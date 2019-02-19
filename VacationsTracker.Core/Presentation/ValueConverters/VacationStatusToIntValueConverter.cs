using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class VacationStatusToIntValueConverter : ValueConverter<VacationStatus, int>
    {
        protected override ConversionResult<int> Convert(VacationStatus value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<int>.SetValue((int)value);
        }

        protected override ConversionResult<VacationStatus> ConvertBack(int value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<VacationStatus>.SetValue((VacationStatus)value);
        }
    }
}
