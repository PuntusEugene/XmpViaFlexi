﻿using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Domain.Vacation;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class VacationTypeToIntValueConverter : ValueConverter<VacationType, int>
    {
        protected override ConversionResult<int> Convert(VacationType value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<int>.SetValue((int)value);
        }
    }
}
