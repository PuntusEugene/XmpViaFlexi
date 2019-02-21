using System;
using System.Globalization;
using Android.Views;
using FlexiMvvm.ValueConverters;

namespace VacationsTracker.Android.ValueConverters
{
    internal class BooleanToVisibleStateValueConverter : ValueConverter<bool, ViewStates>
    {
        protected override ConversionResult<ViewStates> Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            var viewState = value ? ViewStates.Visible : ViewStates.Invisible;

            return ConversionResult<ViewStates>.SetValue(viewState);
        }
    }
}