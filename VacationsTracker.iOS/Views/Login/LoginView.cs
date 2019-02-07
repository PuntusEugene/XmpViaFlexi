using System.Resources;
using System.Security.Authentication;
using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Resourses;
using VacationsTracker.iOS.Design;

namespace VacationsTracker.iOS.Views.Login
{
    public class LoginView : LayoutView
    {

        public UIImageView BackgroundView { get; private set; }

        public UILabel InvalidCredentialLabel { get; private set; }

        public UITextField LoginTextField { get; private set; }

        public UITextField PasswordTextField { get; private set; }

        public UIButton LoginButton { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundView = new UIImageView()
            {
                Image = UIImage.FromBundle("Background"),
                UserInteractionEnabled = false
            };

            InvalidCredentialLabel = new UILabel().SetCredentialLabel(VacationResource.InvalidCredential);

            LoginTextField = new UITextField().SetTextFieldStyle(VacationResource.Login);

            PasswordTextField = new UITextField().SetTextFieldStyle(VacationResource.Password);
            PasswordTextField.SecureTextEntry = true;
            
            LoginButton = new UIButton().SetPrimaryButtonStyle(VacationResource.SignIn);
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(BackgroundView)
                .AddLayoutSubview(InvalidCredentialLabel)
                .AddLayoutSubview(LoginTextField)
                .AddLayoutSubview(PasswordTextField)
                .AddLayoutSubview(LoginButton);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            
            this.AddConstraints(
                BackgroundView.FullSizeOf(this));

            this.AddConstraints(
                InvalidCredentialLabel.AtLeftOf(this, AppDimens.Inset6x),
                InvalidCredentialLabel.AtRightOf(this, AppDimens.Inset6x),
                InvalidCredentialLabel.Height().EqualTo(AppDimens.Inset8x),
                InvalidCredentialLabel.Above(LoginTextField, AppDimens.Inset4x));

            this.AddConstraints(
                LoginTextField.AtLeftOf(this, AppDimens.Inset6x),
                LoginTextField.AtRightOf(this, AppDimens.Inset6x),
                LoginTextField.Height().EqualTo(AppDimens.Inset6x),
                LoginTextField.Above(PasswordTextField, AppDimens.Inset2x));

            this.AddConstraints(
                PasswordTextField.WithSameLeft(LoginTextField),
                PasswordTextField.WithSameRight(LoginTextField),
                PasswordTextField.Height().EqualTo(AppDimens.Inset6x),
                PasswordTextField.WithSameCenterY(this));

            this.AddConstraints(
                LoginButton.WithSameLeft(LoginTextField),
                LoginButton.Below(PasswordTextField, AppDimens.Inset2x),
                LoginButton.WithSameRight(LoginTextField),
                LoginButton.Height().EqualTo(AppDimens.Inset6x));
        }
    }
}