using System;
using System.Globalization;
using FlexiMvvm;
using FlexiMvvm.ValueConverters;
using Foundation;

namespace VacationsTracker.iOS.ValueConverters
{
    internal class DateToNSDateValueConverter : ValueConverter<DateTime, NSDate>
    {
        protected override ConversionResult<NSDate> Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
            var nsDate = NSDate.FromTimeIntervalSinceReferenceDate((value - startTime).TotalSeconds);

            return ConversionResult<NSDate>.SetValue(nsDate);
        }

        protected override ConversionResult<DateTime> ConvertBack(NSDate value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0))
                .AddSeconds(value.NotNull().SecondsSinceReferenceDate);

            return ConversionResult<DateTime>.SetValue(date);
        }
    }
}