using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Resourses;
using VacationsTracker.iOS.Design;

namespace VacationsTracker.iOS.Controls
{
    internal class PlusButtonContol : LayoutView
    {
        public UILabel NewHeaderLabel { get; private set; }

        public UIImageView NewImageView { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            NewHeaderLabel = new UILabel().SetHeaderLabel(Strings.New);
            NewImageView = new UIImageView(AppImages.Plus)
            {
                TintColor = AppColors.TextHeadline
            };
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(NewHeaderLabel)
                .AddLayoutSubview(NewImageView);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                NewHeaderLabel.AtLeftOf(this),
                NewHeaderLabel.WithSameCenterY(this));

            this.AddConstraints(
                NewImageView.ToRightOf(NewHeaderLabel),
                NewImageView.WithSameCenterY(NewHeaderLabel),
                NewImageView.AtRightOf(this),
                NewImageView.Height().EqualTo(AppDimens.Inset4x),
                NewImageView.Width().EqualTo(AppDimens.Inset4x));
        }
    }
}