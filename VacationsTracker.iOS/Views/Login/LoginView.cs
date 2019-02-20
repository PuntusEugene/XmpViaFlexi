using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Resourses;
using VacationsTracker.iOS.Design;
using VacationsTracker.iOS.Views.ActivityIndicator;

namespace VacationsTracker.iOS.Views.Login
{
    public class LoginView : LayoutView
    {
        public UIImageView BackgroundView { get; private set; }

        public UILabel InvalidCredentialLabel { get; private set; }

        public UITextField LoginTextField { get; private set; }

        public UITextField PasswordTextField { get; private set; }

        public UIButton LoginButton { get; private set; }

        public ActivityIndicatorView ActivityIndicatorView { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();
            
            BackgroundView = new UIImageView()
            {
                Image = AppImages.Background,
                UserInteractionEnabled = false
            };

            SetNeedsDisplay();

            InvalidCredentialLabel = new UILabel().SetCredentialLabel(Strings.InvalidCredential);

            LoginTextField = new UITextField().SetTextFieldStyle(Strings.Login);
            LoginTextField.ReturnKeyType = UIReturnKeyType.Next;
            LoginTextField.ShouldReturn = field => PasswordTextField.BecomeFirstResponder();

            PasswordTextField = new UITextField().SetTextFieldStyle(Strings.Password);
            PasswordTextField.SecureTextEntry = true;
            PasswordTextField.ReturnKeyType = UIReturnKeyType.Done;
            PasswordTextField.ShouldReturn = field => PasswordTextField.ResignFirstResponder();

            LoginButton = new UIButton().SetPrimaryButtonStyle(Strings.SignIn);

            ActivityIndicatorView = new ActivityIndicatorView(80, 1);
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(BackgroundView)
                .AddLayoutSubview(InvalidCredentialLabel)
                .AddLayoutSubview(LoginTextField)
                .AddLayoutSubview(PasswordTextField)
                .AddLayoutSubview(LoginButton)
                .AddLayoutSubview(ActivityIndicatorView);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                BackgroundView.FullSizeOf(this));

            this.AddConstraints(
                InvalidCredentialLabel.AtLeftOf(this, AppDimens.Inset6X),
                InvalidCredentialLabel.AtRightOf(this, AppDimens.Inset6X),
                InvalidCredentialLabel.Height().EqualTo(AppDimens.Inset8X),
                InvalidCredentialLabel.Above(LoginTextField, AppDimens.Inset4X));

            this.AddConstraints(
                LoginTextField.AtLeftOf(this, AppDimens.Inset6X),
                LoginTextField.AtRightOf(this, AppDimens.Inset6X),
                LoginTextField.Height().EqualTo(AppDimens.Inset6X),
                LoginTextField.Above(PasswordTextField, AppDimens.Inset2X));

            this.AddConstraints(
                PasswordTextField.WithSameLeft(LoginTextField),
                PasswordTextField.WithSameRight(LoginTextField),
                PasswordTextField.Height().EqualTo(AppDimens.Inset6X),
                PasswordTextField.WithSameCenterY(this));

            this.AddConstraints(
                LoginButton.WithSameLeft(LoginTextField),
                LoginButton.Below(PasswordTextField, AppDimens.Inset2X),
                LoginButton.WithSameRight(LoginTextField),
                LoginButton.Height().EqualTo(AppDimens.Inset6X));

            this.AddConstraints(
                ActivityIndicatorView.WithSameCenterX(this),
                ActivityIndicatorView.WithSameCenterY(this));
        }
    }
}