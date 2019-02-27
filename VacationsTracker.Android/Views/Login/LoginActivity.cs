using Android.App;
using Android.OS;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V7;
using VacationsTracker.Android.ValueConverters;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Login;

namespace VacationsTracker.Android.Views.Login
{
    [Activity(Theme = "@style/AppTheme.Dark.NoActionBar")]
    internal class LoginActivity : FlxBindableAppCompatActivity<LoginViewModel>
    {
        private LoginActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            ViewHolder = new LoginActivityViewHolder(this);
        }

        public override void Bind(BindingSet<LoginViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ViewHolder.InvalidCredentialLabel)
                .For(v => v.Visibility)
                .To(vm => vm.ValidCredentials)
                .WithConvertion<BooleanToVisibleStateInvertedValueConverter>();

            bindingSet.Bind(ViewHolder.LoginTextInput.EditText)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.Username);

            bindingSet.Bind(ViewHolder.PasswordTextInput.EditText)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.Password);

            bindingSet.Bind(ViewHolder.LoginButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.LoginCommand);

            bindingSet.Bind(ViewHolder.LoginTextInput)
                .For(v => v.Error)
                .To(vm => vm.LoginEmptyError);

            bindingSet.Bind(ViewHolder.PasswordTextInput)
                .For(v => v.Error)
                .To(vm => vm.PasswordEmptyError);

            bindingSet.Bind(ViewHolder.LoginButton)
                .For(v => v.TextBinding())
                .To(vm => vm.Loading)
                .WithConvertion<LoadingToTextLoginButtonValueConverter>();

            bindingSet.Bind(ViewHolder.ProgressRingSecond)
                .For(v => v.Visibility)
                .To(vm => vm.Loading)
                .WithConvertion<BooleanToVisibleStateValueConverter>();
        }
    }
}