using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ViewModels.Login;

namespace VacationsTracker.iOS.Views.Login
{
    public class LoginViewController : FlxBindableViewController<LoginViewModel>
    {
        public new LoginView View
        {
            get => (LoginView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new LoginView();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (NavigationController != null)
                NavigationController.NavigationBarHidden = true;
        }

        public override void Bind(BindingSet<LoginViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View.InvalidCredentialLabel)
                .For(v => v.Hidden)
                .To(vm => vm.ValidCredentials);

            bindingSet.Bind(View.LoginTextField)
                .For(v => v.TextAndEditingChangedBinding())
                .To(vm => vm.Username);

            bindingSet.Bind(View.PasswordTextField)
                .For(v => v.TextAndEditingChangedBinding())
                .To(vm => vm.Password);

            bindingSet.Bind(View.LoginButton)
                .For(v => v.TouchUpInsideBinding())
                .To(vm => vm.LoginCommand);

            bindingSet.Bind(View.ActivityIndicatorView)
                .For(v => v.Loading)
                .To(vm => vm.Loading);
        }
    }
}