﻿using System;
using System.Globalization;
using Android.Views;
using FlexiMvvm.ValueConverters;

namespace VacationsTracker.Android.ValueConverters
{
    internal class BooleanToVisibleStateInvertedValueConverter : ValueConverter<bool, ViewStates>
    {
        protected override ConversionResult<ViewStates> Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            var viewState = value ? ViewStates.Invisible : ViewStates.Visible;

            return ConversionResult<ViewStates>.SetValue(viewState);
        }
    }
}