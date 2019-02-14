using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using VacationsTracker.Core.Bootstrappers;
using VacationsTracker.Core.Infrastructure.Storage;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Repositories;
using VacationsTracker.Core.Repositories.Interfaces;
using VacationsTracker.Core.SwaggerApi;
using VacationsTracker.Core.SwaggerApi.Interfaces;
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
            //simpleIoc.Register<INavigationService>(() => new NavigationTabBarService());
            simpleIoc.Register<IIdentityRepository>(() => new IdentityRepository());
            simpleIoc.Register<IVacationSecureStorage>(() => new VacationVacationSecureStorage());
            simpleIoc.Register<IVacationContext>(() => new VacationContext());
            simpleIoc.Register<IVacationApi>(() => new VacationApi(simpleIoc.Get<IVacationContext>(), simpleIoc.Get<IVacationSecureStorage>()));
            simpleIoc.Register<IVacationRepository>(() => new VacationRepository(simpleIoc.Get<IVacationApi>()));
        }
    }
}