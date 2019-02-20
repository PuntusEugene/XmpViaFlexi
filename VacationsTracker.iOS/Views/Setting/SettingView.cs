using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Resourses;
using VacationsTracker.iOS.Design;

namespace VacationsTracker.iOS.Views.Setting
{
    public class SettingView : LayoutView
    {
        public UIView ContentView { get; private set; }

        public UIImageView AvatarImageView { get; private set; }

        public UILabel AvatarLabel { get; private set; }

        public UIButton ChoiceAllButton { get; private set; }

        public UIButton ChoiceOpenButton { get; private set; }

        public UIButton ChoiceClosedButton { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            ContentView = new UIView {BackgroundColor = BackgroundColor = AppColors.ContentPrimary};

            AvatarImageView = new UIImageView
            {
                Image = AppImages.Avatar,
                BackgroundColor = AppColors.ContentPrimary,
            };

            AvatarLabel = new UILabel
            {
                Text = Strings.AvatarTitle,
                TextColor = AppColors.TextPrimary,
                Font = UIFont.FromName("Arial-BoldMT", 24),
                BackgroundColor = AppColors.ContentPrimary,
            };

            ChoiceAllButton = new UIButton()
                .SetChoiceButtonStyle("ALL");

            ChoiceOpenButton = new UIButton()
                .SetChoiceButtonStyle("OPEN");

            ChoiceClosedButton = new UIButton()
                .SetChoiceButtonStyle("CLOSED");
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(AvatarImageView)
                .AddLayoutSubview(AvatarLabel)
                .AddLayoutSubview(ChoiceAllButton)
                .AddLayoutSubview(ChoiceOpenButton)
                .AddLayoutSubview(ChoiceClosedButton);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                AvatarImageView.WithSameCenterX(this),
                AvatarImageView.AtTopOf(this, AppDimens.Inset4X));

            this.AddConstraints(
                AvatarLabel.WithSameCenterX(this),
                AvatarLabel.Below(AvatarImageView, AppDimens.Inset1X));

            this.AddConstraints(
                ChoiceAllButton.AtLeftOf(this),
                ChoiceAllButton.Below(AvatarLabel, AppDimens.Inset1X),
                ChoiceAllButton.AtRightOf(this),
                ChoiceAllButton.Height().EqualTo(AppDimens.ButtonSize));

            this.AddConstraints(
                ChoiceOpenButton.AtLeftOf(this),
                ChoiceOpenButton.Below(ChoiceAllButton),
                ChoiceOpenButton.AtRightOf(this),
                ChoiceOpenButton.Height().EqualTo(AppDimens.ButtonSize));

            this.AddConstraints(
                ChoiceClosedButton.AtLeftOf(this),
                ChoiceClosedButton.Below(ChoiceOpenButton),
                ChoiceClosedButton.AtRightOf(this),
                ChoiceClosedButton.Height().EqualTo(AppDimens.ButtonSize));
        }
    }
}