using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class MonthOfDateToStringValueConverter : ValueConverter<DateTime, string>
    {
        protected override ConversionResult<string> Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value.ToString("MMM").ToUpper(CultureInfo.CurrentCulture);
            return ConversionResult<string>.SetValue(text);
        }
    }
}
