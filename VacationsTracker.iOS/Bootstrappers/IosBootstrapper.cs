﻿using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using VacationsTracker.Core.Bootstrappers;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Services;
using VacationsTracker.Core.Services.Interfaces;
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
            simpleIoc.Register<IIdentityService>(() => new IdentityService());
            simpleIoc.Register<IVacationService>(() => new VacationService());
        }
    }
}