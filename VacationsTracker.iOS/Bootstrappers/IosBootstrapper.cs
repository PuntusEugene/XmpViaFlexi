using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using VacationsTracker.Core.Api;
using VacationsTracker.Core.Api.Interfaces;
using VacationsTracker.Core.Bootstrappers;
using VacationsTracker.Core.Infrastructure.Storage;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Repositories;
using VacationsTracker.Core.Repositories.Interfaces;
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
            //simpleIoc.Register<IVacationSecureStorage>(() => new VacationSecureStorage());
            //simpleIoc.Register<IVacationApiContext>(() => new VacationApiContext());
            //simpleIoc.Register<IIdentityApi>(() => new IdentityApi(simpleIoc.Get<IVacationSecureStorage>()));
            //simpleIoc.Register<IVacationApi>(() => new VacationApi(simpleIoc.Get<IVacationApiContext>(), simpleIoc.Get<IIdentityApi>()));
            //simpleIoc.Register<IIdentityRepository>(() => new IdentityRepository(simpleIoc.Get<IIdentityApi>()));
            //simpleIoc.Register<IVacationRepository>(() => new VacationRepository(simpleIoc.Get<IVacationApi>()));
        }
    }
}