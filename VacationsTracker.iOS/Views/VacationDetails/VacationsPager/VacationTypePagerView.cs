using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Design;

namespace VacationsTracker.iOS.Views.VacationDetails.VacationsPager
{
    internal class VacationTypePagerView : LayoutView
    {
        public UIImageView VacationTypeImageView { get; private set; }

        public UILabel VacationTypeLabel { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            VacationTypeImageView = new UIImageView();

            VacationTypeLabel = new UILabel()
                .SetBodyLabelStyle(28);
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(VacationTypeImageView)
                .AddLayoutSubview(VacationTypeLabel);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                VacationTypeImageView.WithSameCenterX(this),
                VacationTypeImageView.WithSameCenterY(this),
                VacationTypeImageView.Width().EqualTo(AppDimens.Inset8x),
                VacationTypeImageView.Height().EqualTo(AppDimens.Inset8x));

            this.AddConstraints(
                VacationTypeLabel.Below(VacationTypeImageView, AppDimens.Inset1x),
                VacationTypeLabel.WithSameCenterX(this));
        }
    }
}