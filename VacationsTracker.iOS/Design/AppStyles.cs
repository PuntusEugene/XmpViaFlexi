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

            button.BackgroundColor = AppColors.ButtonPrimary;
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
            textField.BackgroundColor = AppColors.ContentPrimary;
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
            label.TextColor = AppColors.TextError;
            label.BackgroundColor = AppColors.ContentPrimary;
            label.TextAlignment = UITextAlignment.Center;
            label.Font = UIFont.FromName(label.Font.Name, 10f);
            label.Layer.MasksToBounds = true;
            label.Layer.CornerRadius = AppDimens.Inset1x;

            return label;
        }

        public static UILabel SetBodyLabelStyle(this UILabel label, float size)
        {
            if (size >= 0)
            {
                label.Font = UIFont.FromName("Arial-BoldMT", size);
            }
            label.TextColor = AppColors.TextBody;

            return label;
        }

        public static UILabel SetPrimaryLabelStyle(this UILabel label, float size = 13)
        {
            label.Font = UIFont.FromName("Arial-BoldMT", size);
            label.TextColor = AppColors.TextPrimary;

            return label;
        }

        public static UILabel SetHeaderLabelStyle(this UILabel label, string text)
        {
            label.Text = text;
            label.TextColor = AppColors.TextHeadline;
            label.Font = UIFont.FromName("Arial-BoldMT", label.Font.PointSize);

            return label;
        }

        public static UIView SetSeparatorStyle(this UIView view)
        {
            view.BackgroundColor = AppColors.SeparatorPrimary;

            return view;
        }

        public static UIBarButtonItem SetHeaderBarButtonItemStyle(this UIBarButtonItem barButtonItem, string text = null, int size = 17)
        {
            if (text != null)
            {
                barButtonItem.Title = text;
            }

            barButtonItem.SetTitleTextAttributes(new UITextAttributes() { Font = UIFont.FromName("Arial", size), TextColor = AppColors.TextHeadline }, UIControlState.Normal);

            return barButtonItem;
        }
        
        public static UILabel SetHeaderLabelByBarButtonStyle(this UILabel label, string text, int size = 17)
        {
            label.Text = text;
            label.TextColor = AppColors.TextHeadline;
            label.Font = UIFont.FromName("Arial", size);

            return label;
        }
    }
}