﻿using Cirrious.FluentLayouts.Touch;
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
                .SetPrimaryLabel();

            VacationTypeLabel = new UILabel()
                .SetBodyLabel(8);

            VacationStatusLabel = new UILabel()
                .SetBodyLabel(10);

            ArrowImageView = new UIImageView
            {
                Image = UIImage.FromBundle("RightArrow")
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
                VacationTypeImageView.AtLeftOf(this, AppDimens.Inset1x),
                VacationTypeImageView.AtTopOf(this, AppDimens.Inset1x),
                VacationTypeImageView.AtBottomOf(this, AppDimens.Inset1x),
                VacationTypeImageView.WithSameCenterY(this),
                VacationTypeImageView.Height().EqualTo(AppDimens.Inset5x),
                VacationTypeImageView.Width().EqualTo(AppDimens.Inset5x));

            this.AddConstraints(
                VacationDurationLabel.AtTopOf(this, AppDimens.Inset1x),
                VacationDurationLabel.ToRightOf(VacationTypeImageView, AppDimens.Inset1x),
                VacationDurationLabel.WithRelativeHeight(this, 0.5f),
                VacationDurationLabel.Above(VacationTypeLabel)
                );

            this.AddConstraints(
                VacationTypeLabel.WithSameLeft(VacationDurationLabel),
                VacationTypeLabel.WithSameRight(VacationDurationLabel),
                VacationTypeLabel.AtBottomOf(this, AppDimens.Inset1x));

            this.AddConstraints(
                VacationStatusLabel.Height().EqualTo(56),
                VacationStatusLabel.AtRightOf(ArrowImageView, AppDimens.Inset2x),
                VacationStatusLabel.WithSameCenterY(this));

            this.AddConstraints(
                ArrowImageView.AtRightOf(this, AppDimens.Inset1x),
                ArrowImageView.Width().EqualTo(AppDimens.Inset1x),
                ArrowImageView.Height().EqualTo(AppDimens.Inset1x),
                ArrowImageView.WithSameCenterY(this));
        }
    }
}