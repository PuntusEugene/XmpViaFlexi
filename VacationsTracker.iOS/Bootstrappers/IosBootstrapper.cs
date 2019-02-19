using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using VacationsTracker.Core.Bootstrappers;
using VacationsTracker.Core.Infrastructure.Logger;
using VacationsTracker.Core.Infrastructure.Operations;
using VacationsTracker.Core.Navigation;
using VacationsTracker.iOS.Infrastructure;
using VacationsTracker.iOS.Navigation;

namespace VacationsTracker.iOS.Bootstrappers
{
    public class IosBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<INavigationService>(() => new NavigationService());
            simpleIoc.Register<IVacationLogger>(() => new VacationLogger());
            simpleIoc.Register<IDialogService>(() => new DialogService(simpleIoc.Get<IVacationLogger>()));
        }
    }
}