using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Design;

namespace VacationsTracker.iOS.Views.Home.VacationsTable
{
    internal class VacationItemView : LayoutView
    {
        // TODO vacation cell View
        public  UIImageView VacationStatusImage { get; private set; }

        public UILabel VacationDurationLabel { get; private set; }

        public UILabel VacationStatusLabel { get; private set; }

        public UILabel VacationTypeLabel { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();
            
            VacationStatusImage = new UIImageView();
            VacationStatusImage.Image = UIImage.FromBundle("Regular");

            VacationDurationLabel = new UILabel()
                .SetPrimaryLabel();

            VacationDurationLabel.Text = "MAR 20 - Mar31";

            VacationStatusLabel = new UILabel()
                .SetColorLabel(Colors.Label)
                .SetFontSizeLabel(8);
            VacationStatusLabel.Text = "Regular";

            VacationTypeLabel = new UILabel()
                .SetColorLabel(Colors.Label)
                .SetFontSizeLabel(10);
            VacationTypeLabel.Text = "Approved";
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(VacationStatusImage)
                .AddLayoutSubview(VacationDurationLabel)
                .AddLayoutSubview(VacationStatusLabel)
                .AddLayoutSubview(VacationTypeLabel);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                VacationStatusImage.AtLeftOf(this, AppDimens.Inset1x),
                VacationStatusImage.AtTopOf(this, AppDimens.Inset1x),
                VacationStatusImage.WithSameHeight(this),
                VacationStatusImage.Width().EqualTo(48));


            this.AddConstraints(
                VacationDurationLabel.Left().EqualTo().RightOf(VacationStatusImage).Plus(AppDimens.Inset1x),
                VacationDurationLabel.WithSameCenterY(this).Minus(AppDimens.Inset1x),
                VacationDurationLabel.Above(VacationStatusLabel));


            //this.AddConstraints(
            //    VacationDurationLabel.Left().EqualTo().RightOf(VacationStatusImage).Plus(AppDimens.Inset1x),
            //    VacationDurationLabel.WithSameTop(this),
            //    VacationDurationLabel.Bottom().EqualTo(this.Center.Y),
            //    VacationDurationLabel.Above(VacationStatusLabel));

            this.AddConstraints(
                VacationStatusLabel.WithSameLeft(VacationDurationLabel),
                VacationStatusLabel.WithSameRight(VacationDurationLabel));

            this.AddConstraints(
                VacationTypeLabel.Height().EqualTo(56),
                VacationTypeLabel.AtRightOf(this, AppDimens.Inset1x),
                VacationTypeLabel.WithSameCenterY(this));
        }
    }
}