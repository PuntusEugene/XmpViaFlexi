using Android.App;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views.Animations;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V7;
using VacationsTracker.Android.ValueConverters;
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

            //dynamic animate = ViewHolder.ProgressRing.Background;
            //animate.Start();
            //AnimationUtils.LoadAnimation(ViewHolder.ProgressRing.Context, Resource.Drawable.progress_ring_animate);

            //ViewHolder.ProgressRing.Animate().RotationBy(360).SetDuration(3000).SetInterpolator(new LinearInterpolator()).Start();
            //var animation = (AnimationDrawable)ViewHolder.ProgressRingSecond.Drawable;
            //animation.Start();
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
        }
    }
}