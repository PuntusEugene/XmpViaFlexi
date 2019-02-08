using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using Foundation;
using UIKit;
using VacationsTracker.iOS.Design;
using AdvancedFluentLayoutExtensions = Cirrious.FluentLayouts.Touch.AdvancedFluentLayoutExtensions;

namespace VacationsTracker.iOS.Controls
{
    internal class LargeDateControl : LayoutView
    {
        public UILabel DayOfDateLabel { get; private set; }

        public UILabel MonthOfDateLabel { get; private set; }

        public UILabel YearOfDateLabel { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            DayOfDateLabel = new UILabel()
                .SetPrimaryLabel(48);

            MonthOfDateLabel = new UILabel()
                .SetPrimaryLabel(28);

            YearOfDateLabel = new UILabel()
                .SetPrimaryLabel(20);
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

            this.AddConstraints(
                DayOfDateLabel.AtLeftOf(this, AppDimens.Inset1x),
                DayOfDateLabel.AtTopOf(this));

            this.AddConstraints(
                MonthOfDateLabel.AtLeftOf(DayOfDateLabel, AppDimens.Inset1x),
                MonthOfDateLabel.AtRightOf(this, AppDimens.Inset1x));

            this.AddConstraints(
                YearOfDateLabel.Below(MonthOfDateLabel, AppDimens.Inset1x),
                YearOfDateLabel.WithSameLeft(MonthOfDateLabel),
                YearOfDateLabel.WithSameRight(MonthOfDateLabel));
        }
    }
}