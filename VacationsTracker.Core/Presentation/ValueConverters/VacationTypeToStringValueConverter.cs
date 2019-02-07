using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Domain.Vacation;
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
                    text = VacationResource.Regular;
                    break;

                case VacationType.Exceptional:
                    text = VacationResource.ExceptionalLeave;
                    break;

                case VacationType.Overtime:
                    text = VacationResource.Overtime;
                    break;

                case VacationType.Sick:
                    text = VacationResource.SickDays;
                    break;


                case VacationType.LeaveWithoutPay:
                    text = VacationResource.LeaveWithoutPay;
                    break;


                case VacationType.Undefined:
                    text = VacationResource.Undefined;
                    break;
            }

            return ConversionResult<string>.SetValue(text);
        }
    }
}
