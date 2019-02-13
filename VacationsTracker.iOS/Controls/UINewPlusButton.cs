using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using Foundation;
using UIKit;
using VacationsTracker.Core.Resourses;
using VacationsTracker.iOS.Design;

namespace VacationsTracker.iOS.Controls
{
    internal class UINewPlusButton : UIButton
    {
        public UINewPlusButton()
        {
            var textStringAttributes = new UIStringAttributes
            {
                BaselineOffset = 10
            };

            var plusStringAttributes = new UIStringAttributes
            {
                Font = UIFont.FromName("Arial", 42),
            };

            var mutableAttributedString = new NSMutableAttributedString(Strings.NewWithPlus);
            mutableAttributedString.SetAttributes(textStringAttributes, new NSRange(0, 4));
            mutableAttributedString.SetAttributes(plusStringAttributes, new NSRange(4, 1));

            var newHeaderLabel = new UILabel().SetHeaderLabelByBarButtonStyle(Strings.NewWithPlus);
            newHeaderLabel.AttributedText = mutableAttributedString;
            newHeaderLabel.UserInteractionEnabled = false;

            this.AddLayoutSubview(newHeaderLabel);
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            this.AddConstraints(newHeaderLabel.AtLeftOf(this), newHeaderLabel.AtTopOf(this), newHeaderLabel.AtRightOf(this), newHeaderLabel.AtBottomOf(this));
        }
    }
}