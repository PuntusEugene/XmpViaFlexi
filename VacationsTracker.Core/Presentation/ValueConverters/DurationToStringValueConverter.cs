using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using FlexiMvvm.ValueConverters;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class DurationToStringValueConverter : ValueConverter<(DateTime, DateTime), string>
    {
        protected override ConversionResult<string> Convert((DateTime, DateTime) value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = string.Format($"{value.Item1:MMM dd} - {value.Item2:MMM dd}")
                .ToUpper(CultureInfo.CurrentCulture);

            return ConversionResult<string>.SetValue(text);
        }
    }
}
