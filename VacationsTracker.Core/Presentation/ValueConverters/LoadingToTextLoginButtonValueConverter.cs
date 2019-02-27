using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Resourses;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class LoadingToTextLoginButtonValueConverter : ValueConverter<bool, string>
    {
        protected override ConversionResult<string> Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = value ? string.Empty : Strings.SignIn;

            return ConversionResult<string>.SetValue(result);
        }
    }
}
