using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using VacationsTracker.Android.Infrastructure;
using VacationsTracker.Android.Navigation;
using VacationsTracker.Core.Bootstrappers;
using VacationsTracker.Core.Infrastructure.Operations;
using VacationsTracker.Core.Navigation;

namespace VacationsTracker.Android.Bootstrappers
{
    public class AndroidBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<INavigationService>(() => new NavigationService());
            simpleIoc.Register<IDialogService>(() => new DialogService());
        }
    }
}