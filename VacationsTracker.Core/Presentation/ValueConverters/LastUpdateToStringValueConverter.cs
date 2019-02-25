using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Resourses;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class LastUpdateToStringValueConverter : ValueConverter<DateTime, string>
    {
        protected override ConversionResult<string> Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = $"{Strings.LastUpdateText}: {value.ToString(CultureInfo.CurrentCulture)}";

            return ConversionResult<string>.SetValue(result);
        }
    }
}
