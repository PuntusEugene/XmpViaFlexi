using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using UIKit;
using VacationsTracker.Core.Domain.Vacation;

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
                    image = UIImage.FromBundle("IconRequestGreen");
                    break;

                case VacationType.Exceptional:
                    image = UIImage.FromBundle("IconRequestDark");
                    break;

                case VacationType.Overtime:
                    image = UIImage.FromBundle("IconRequestBlue");
                    break;

                case VacationType.Sick:
                    image = UIImage.FromBundle("IconRequestRed");
                    break;

                case VacationType.LeaveWithoutPay:
                    image = UIImage.FromBundle("IconRequestGreen");
                    break;

                case VacationType.Undefined:
                    image = UIImage.FromBundle("IconRequestRed");
                    break;
            }

            return ConversionResult<UIImage>.SetValue(image);
        }
    }
}