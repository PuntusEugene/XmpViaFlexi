using FlexiMvvm;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using FlexiMvvm.Operations;
using VacationsTracker.Core.Api;
using VacationsTracker.Core.Api.Interfaces;
using VacationsTracker.Core.Application.Connectivity;
using VacationsTracker.Core.Infrastructure;
using VacationsTracker.Core.Infrastructure.Connectivity;
using VacationsTracker.Core.Infrastructure.Storage;
using VacationsTracker.Core.Presentation;
using VacationsTracker.Core.Repositories;
using VacationsTracker.Core.Repositories.Interfaces;
using Connectivity = VacationsTracker.Core.Infrastructure.Connectivity.Connectivity;

namespace VacationsTracker.Core.Bootstrappers
{
    public class CoreBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
            SetupViewModelLocator(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<IConnectivity>(() => Connectivity.Instance);
            simpleIoc.Register<IConnectivityService>(() => new ConnectivityService(simpleIoc.Get<IConnectivity>()), Reuse.Singleton);

            simpleIoc.Register<IErrorHandler>(() => new VacationErrorHandler());
            simpleIoc.Register<IOperationFactory>(() => new OperationFactory(simpleIoc, simpleIoc.Get<IErrorHandler>()));

            simpleIoc.Register<IVacationSecureStorage>(() => new VacationSimulatorSecureStorage());

            simpleIoc.Register<IVacationApiContext>(() => new VacationRestApiContext());
            simpleIoc.Register<IIdentityApi>(() => new IdentityApi(simpleIoc.Get<IVacationSecureStorage>()));
            simpleIoc.Register<IVacationApi>(() => new VacationApi(simpleIoc.Get<IVacationApiContext>(), simpleIoc.Get<IIdentityApi>()));
            simpleIoc.Register<IIdentityRepository>(() => new IdentityRepository(simpleIoc.Get<IIdentityApi>()));
            simpleIoc.Register<IVacationRepository>(() => new VacationRepository(simpleIoc.Get<IVacationApi>()));
        }

        private void SetupViewModelLocator(IDependencyProvider dependencyProvider)
        {
            ViewModelLocator.SetLocator(new VacationsTrackerViewModelLocator(dependencyProvider));
        }
    }
}
