using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Design;

namespace VacationsTracker.iOS.Views.Home.VacationsTable
{
    internal class VacationItemView : LayoutView
    {
        public  UIImageView VacationTypeImageView { get; private set; }

        public UILabel VacationDurationLabel { get; private set; }

        public UILabel VacationTypeLabel { get; private set; }

        public UILabel VacationStatusLabel { get; private set; }

        public UIImageView ArrowImageView { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();
            
            VacationTypeImageView = new UIImageView();

            VacationDurationLabel = new UILabel()
                .SetPrimaryLabelStyle();

            VacationTypeLabel = new UILabel()
                .SetBodyLabelStyle(8);

            VacationStatusLabel = new UILabel()
                .SetBodyLabelStyle(10);

            ArrowImageView = new UIImageView
            {
                Image = AppImages.RightArrow
            };
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(VacationTypeImageView)
                .AddLayoutSubview(VacationDurationLabel)
                .AddLayoutSubview(VacationTypeLabel)
                .AddLayoutSubview(VacationStatusLabel)
                .AddLayoutSubview(ArrowImageView);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                VacationTypeImageView.AtLeftOf(this, AppDimens.Inset1X),
                VacationTypeImageView.WithSameCenterY(this),
                VacationTypeImageView.Height().EqualTo(AppDimens.Inset5X),
                VacationTypeImageView.Width().EqualTo(AppDimens.Inset5X));

            this.AddConstraints(
                VacationDurationLabel.AtTopOf(this, AppDimens.Inset1X),
                VacationDurationLabel.ToRightOf(VacationTypeImageView, AppDimens.Inset1X)
                );

            this.AddConstraints(
                VacationTypeLabel.Below(VacationDurationLabel, 4),
                VacationTypeLabel.WithSameLeft(VacationDurationLabel),
                VacationTypeLabel.AtBottomOf(this, AppDimens.Inset1X));

            this.AddConstraints(
                VacationStatusLabel.Height().EqualTo(56),
                VacationStatusLabel.AtRightOf(ArrowImageView, AppDimens.Inset2X),
                VacationStatusLabel.WithSameCenterY(this));

            this.AddConstraints(
                ArrowImageView.AtRightOf(this, AppDimens.Inset1X),
                ArrowImageView.Width().EqualTo(AppDimens.Inset1X),
                ArrowImageView.Height().EqualTo(AppDimens.Inset1X),
                ArrowImageView.WithSameCenterY(this));
        }
    }
}