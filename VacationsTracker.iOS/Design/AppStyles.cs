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
        public static UIButton SetPrimaryButtonStyle(this UIButton button, string text = null)
        {
            if (text != null)
            {
                button.SetTitle(text, UIControlState.Normal);
            }

            button.BackgroundColor = AppColors.Primary;
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
            textField.BackgroundColor = AppColors.Header;
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
            label.TextColor = AppColors.Error;
            label.BackgroundColor = AppColors.Header;
            label.TextAlignment = UITextAlignment.Center;
            label.Font = UIFont.FromName(label.Font.Name, 10f);

            return label;
        }

        public static UILabel SetBodyLabel(this UILabel label, float size)
        {
            if (size >= 0)
            {
                label.Font = UIFont.FromName(label.Font.Name, size);
            }
            label.TextColor = AppColors.Body;

            return label;
        }

        public static UILabel SetPrimaryLabel(this UILabel label, float size = 13)
        {
            label.Font = UIFont.FromName("Arial-BoldMT", size);
            label.TextColor = AppColors.Primary;

            return label;
        }

        public static UILabel SetHeaderLabel(this UILabel label, string text)
        {
            label.Text = text;
            label.TextColor = AppColors.Header;

            return label;
        }
    }
}