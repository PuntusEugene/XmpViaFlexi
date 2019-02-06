using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace VacationsTracker.iOS.Design
{
    public static class AppStyles
    {
        public static UIImageView SetBackgroundStyle(this UIImageView imageView)
        {
            imageView.Image = UIImage.FromBundle("Background");
            return imageView;
        }

        public static UIButton SetPrimaryButtonStyle(this UIButton button, string text = null)
        {
            if (text != null)
            {
                button.SetTitle(text, UIControlState.Normal);
            }

            button.BackgroundColor = Colors.Primary;
            button.Layer.CornerRadius = AppDimens.Inset1x;

            return button;
        }

        public static UITextField SetTextFieldStyle(this UITextField textField, string placeholder = null)
        {
            if (placeholder != null)
            {
                textField.Placeholder = placeholder;
            }

            textField.MinimumFontSize = 17;
            textField.AdjustsFontSizeToFitWidth = true;
            textField.BorderStyle = UITextBorderStyle.RoundedRect;
            textField.BackgroundColor = Colors.Header;
            textField.Enabled = true;
            textField.Layer.CornerRadius = AppDimens.Inset1x;

            return textField;
        }

        public static UILabel SetCredentialLabel(this UILabel label, string text = null)
        {
            if (text != null)
            {
                label.Text = text;
            }

            label.Lines = 0;
            label.AdjustsFontSizeToFitWidth = false;
            label.TextColor = Colors.Error;
            label.BackgroundColor = Colors.Header;
            label.TextAlignment = UITextAlignment.Center;
            label.Font = UIFont.FromName(label.Font.Name, 10f);

            return label;
        }

        public static UILabel SetFontSizeLabel(this UILabel label, float size)
        {
            if (size >= 0)
            {
                label.Font = UIFont.FromName(label.Font.Name, size);
            }

            return label;
        }
        public static UILabel SetPrimaryLabel(this UILabel label, float size = 13)
        {
            label.Font = UIFont.BoldSystemFontOfSize(size);
            label.TextColor = Colors.Primary;

            return label;
        }

        public static UILabel SetColorLabel(this UILabel label, UIColor color)
        {
            label.TextColor = color;
            return label;
        }
    }
}