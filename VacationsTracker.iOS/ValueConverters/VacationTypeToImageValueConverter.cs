using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using UIKit;
using VacationsTracker.Core.Domain.Vacation;
using VacationsTracker.iOS.Design;

namespace VacationsTracker.iOS.ValueConverters
{
    internal class VacationTypeToImageValueConverter : ValueConverter<VacationType, UIImage>
    {
        protected override ConversionResult<UIImage> Convert(VacationType value, Type targetType, object parameter, CultureInfo culture)
        {
            UIImage image = null;

            switch (value)
            {
                case VacationType.Regular:
                    image = AppImages.IconRequestGreen;
                    break;

                case VacationType.Exceptional:
                    image = AppImages.IconRequestDark;
                    break;

                case VacationType.Overtime:
                    image = AppImages.IconRequestBlue;
                    break;

                case VacationType.Sick:
                    image = AppImages.IconRequestRed;
                    break;

                case VacationType.LeaveWithoutPay:
                    image = AppImages.IconRequestOrange;
                    break;

                case VacationType.Undefined:
                    image = AppImages.IconRequestGrey;
                    break;
            }

            return ConversionResult<UIImage>.SetValue(image);
        }
    }
}