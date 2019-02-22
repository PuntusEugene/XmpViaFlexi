using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Android.ValueConverters
{
    internal class VacationTypeToResourceImageValueConverter : ValueConverter<VacationType, int>
    {
        protected override ConversionResult<int> Convert(VacationType value, Type targetType, object parameter, CultureInfo culture)
        {
            int resourseId;

            switch (value)
            {
                case VacationType.Regular:
                    resourseId = Resource.Drawable.Icon_Request_Green;
                    break;

                case VacationType.Exceptional:
                    resourseId = Resource.Drawable.Icon_Request_Dark;
                    break;

                case VacationType.Overtime:
                    resourseId = Resource.Drawable.Icon_Request_Blue;
                    break;

                case VacationType.Sick:
                    resourseId = Resource.Drawable.Icon_Request_Plum;
                    break;

                case VacationType.LeaveWithoutPay:
                    resourseId = Resource.Drawable.Icon_Request_Orange;
                    break;

                default:
                    resourseId = Resource.Drawable.Icon_Request_Gray;
                    break;
            }

            return ConversionResult<int>.SetValue(resourseId);
        }
    }
}