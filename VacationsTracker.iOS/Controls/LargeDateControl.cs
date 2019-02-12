using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Design;

namespace VacationsTracker.iOS.Controls
{
    internal class LargeDateControl : LayoutView
    {
        public UILabel DayOfDateLabel { get; private set; }

        public UILabel MonthOfDateLabel { get; private set; }

        public UILabel YearOfDateLabel { get; private set; }

        public LargeDateControl(UIColor colorControl)
        {
            DayOfDateLabel.TextColor = colorControl;
            MonthOfDateLabel.TextColor = colorControl;
            YearOfDateLabel.TextColor = colorControl;
        }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            DayOfDateLabel = new UILabel()
                .SetPrimaryLabel(72);

            MonthOfDateLabel = new UILabel()
                .SetPrimaryLabel(28);
            MonthOfDateLabel.TextAlignment = UITextAlignment.Right;

            YearOfDateLabel = new UILabel()
                .SetPrimaryLabel(20);
            YearOfDateLabel.TextAlignment = UITextAlignment.Right;
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(DayOfDateLabel)
                .AddLayoutSubview(MonthOfDateLabel)
                .AddLayoutSubview(YearOfDateLabel);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                DayOfDateLabel.AtLeftOf(this,AppDimens.Inset1x),
                DayOfDateLabel.AtTopOf(this));

            this.AddConstraints(
                MonthOfDateLabel.ToRightOf(DayOfDateLabel,AppDimens.Inset1x),
                MonthOfDateLabel.WithSameTop(DayOfDateLabel),
                MonthOfDateLabel.WithRelativeHeight(DayOfDateLabel, 0.5f));

            this.AddConstraints(
                YearOfDateLabel.Below(MonthOfDateLabel, AppDimens.Inset1x),
                YearOfDateLabel.WithSameLeft(MonthOfDateLabel),
                YearOfDateLabel.WithSameRight(MonthOfDateLabel));
        }
    }
}