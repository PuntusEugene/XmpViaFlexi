using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Domain.Vacation;
using VacationsTracker.Core.Resourses;

namespace VacationsTracker.Core.Presentation.ValueConverters
{
    public class VacationStatusToStringValueConverter : ValueConverter<VacationStatus, string>
    {
        protected override ConversionResult<string> Convert(VacationStatus value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = String.Empty;

            switch (value)
            {
                case VacationStatus.Approved:
                    text = VacationResource.Approved;
                    break;

                case VacationStatus.Closed:
                    text = VacationResource.Closed;
                    break;


                case VacationStatus.Draft:
                    text = VacationResource.Draft;
                    break;


                case VacationStatus.InProgress:
                    text = VacationResource.InProgress;
                    break;


                case VacationStatus.Submitted:
                    text = VacationResource.Submitted;
                    break;
            }

            return ConversionResult<string>.SetValue(text);
        }
    }
}
