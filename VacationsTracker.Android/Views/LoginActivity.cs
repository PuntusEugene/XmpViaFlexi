using Android.App;
using Android.OS;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V7;
using VacationsTracker.Android.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Core.Resourses;

namespace VacationsTracker.Android.Views
{
    [Activity(Label = "LoginActivity", Theme = "@style/AppTheme.Dark.NoActionBar")]
    public class LoginActivity : FlxBindableAppCompatActivity<LoginViewModel>
    {
        private LoginActivityViewHolder ActivityViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            ActivityViewHolder = new LoginActivityViewHolder(this);
        }

        public override void Bind(BindingSet<LoginViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ActivityViewHolder.InvalidCredentialLabel)
                .For(v => v.Visibility)
                .To(vm => vm.ValidCredentials)
                .WithConvertion<BooleanToVisibleStateInvertedValueConverter>();

            bindingSet.Bind(ActivityViewHolder.LoginTextInput.EditText)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.Username);

            bindingSet.Bind(ActivityViewHolder.PasswordTextInput.EditText)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.Password);

            bindingSet.Bind(ActivityViewHolder.LoginButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.LoginCommand);

            bindingSet.Bind(ActivityViewHolder.LoginTextInput)
                .For(v => v.Error)
                .To(vm => vm.LoginEmptyError);

            bindingSet.Bind(ActivityViewHolder.PasswordTextInput)
                .For(v => v.Error)
                .To(vm => vm.PasswordEmptyError);
        }
    }
}