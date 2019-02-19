using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Domain;
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
                    text = Strings.Approved;
                    break;

                case VacationStatus.Closed:
                    text = Strings.Closed;
                    break;


                case VacationStatus.Draft:
                    text = Strings.Draft;
                    break;


                case VacationStatus.InProgress:
                    text = Strings.InProgress;
                    break;


                case VacationStatus.Submitted:
                    text = Strings.Submitted;
                    break;
            }

            return ConversionResult<string>.SetValue(text);
        }
    }
}
