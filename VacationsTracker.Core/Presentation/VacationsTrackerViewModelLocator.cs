﻿using FlexiMvvm;
using FlexiMvvm.Ioc;
using FlexiMvvm.Operations;
using VacationsTracker.Core.Infrastructure.Operations;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Core.Presentation.ViewModels.Setting;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails.VacationPager;
using VacationsTracker.Core.Repositories.Interfaces;

namespace VacationsTracker.Core.Presentation
{
    public class VacationsTrackerViewModelLocator : ViewModelLocatorBase
    {
        private readonly IDependencyProvider _dependencyProvider;

        public VacationsTrackerViewModelLocator(IDependencyProvider dependencyProvider)
        {
            _dependencyProvider = dependencyProvider;
        }

        protected override void SetupFactory(ViewModelFactory factory)
        {
            factory.Register(() => new EntryViewModel(_dependencyProvider.Get<INavigationService>()));
            factory.Register(() => new LoginViewModel(_dependencyProvider.Get<INavigationService>(), _dependencyProvider.Get<IIdentityRepository>(), _dependencyProvider.Get<IDialogService>(), _dependencyProvider.Get<IOperationFactory>()));
            factory.Register(() => new HomeViewModel(_dependencyProvider.Get<INavigationService>(), _dependencyProvider.Get<IVacationRepository>(), _dependencyProvider.Get<IIdentityRepository>(), _dependencyProvider.Get<IDialogService>(), _dependencyProvider.Get<IOperationFactory>()));
            factory.Register(() => new VacationDetailsViewModel(_dependencyProvider.Get<INavigationService>(), _dependencyProvider.Get<IVacationRepository>(), _dependencyProvider.Get<IDialogService>(), _dependencyProvider.Get<IOperationFactory>()));
            factory.Register(() => new VacationTypePagerViewModel());
            factory.Register(() => new SettingViewModel());
        }
    }
}
