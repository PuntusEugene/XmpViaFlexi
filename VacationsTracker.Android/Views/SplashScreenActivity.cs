using System.Threading.Tasks;
using Android.App;
using Android.OS;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using FlexiMvvm.Views.V7;
using Plugin.CurrentActivity;
using VacationsTracker.Android.Bootstrappers;
using VacationsTracker.Core.Bootstrappers;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Android.Views
{
    [Activity(Theme = "@style/AppTheme.SplashScreen",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashScreenActivity : FlxAppCompatActivity<EntryViewModel>
    {
        private Task _taskWait;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            _taskWait = Task.Delay(3000);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            var config = new BootstrapperConfig();
            config.SetSimpleIoc(new SimpleIoc());

            var compositeBootstrapper = new CompositeBootstrapper(
                new CoreBootstrapper(),
                new AndroidBootstrapper());

            compositeBootstrapper.Execute(config);

            base.OnCreate(savedInstanceState);

            _taskWait.Wait();
        }
    }
}