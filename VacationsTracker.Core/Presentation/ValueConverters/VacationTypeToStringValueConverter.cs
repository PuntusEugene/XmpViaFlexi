using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Resourses;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class VacationTypeToStringValueConverter : ValueConverter<VacationType, string>
    {
        protected override ConversionResult<string> Convert(VacationType value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = String.Empty;

            switch (value)
            {
                case VacationType.Regular:
                    text = Strings.Regular;
                    break;

                case VacationType.Exceptional:
                    text = Strings.ExceptionalLeave;
                    break;

                case VacationType.Overtime:
                    text = Strings.Overtime;
                    break;

                case VacationType.Sick:
                    text = Strings.SickDays;
                    break;

                case VacationType.LeaveWithoutPay:
                    text = Strings.LeaveWithoutPay;
                    break;

                case VacationType.Undefined:
                    text = Strings.Undefined;
                    break;
            }

            return ConversionResult<string>.SetValue(text);
        }
    }
}
