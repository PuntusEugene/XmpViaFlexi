﻿using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Core.Resourses;
using VacationsTracker.iOS.Controls;
using VacationsTracker.iOS.Design;
using VacationsTracker.iOS.Views.Home.VacationsTable;

namespace VacationsTracker.iOS.Views.Home
{
    internal class HomeViewController : FlxBindableViewController<HomeViewModel>
    {
        private UINewPlusButton _uiNewPlusButton;

        private UITableViewObservablePlainSource VacationsSource { get; set; }
        
        public new HomeView View
        {
            get => (HomeView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new HomeView();
            NavigationController.NavigationBarHidden = false;
            NavigationController.NavigationBar.BarTintColor = AppColors.TextPrimary;

            _uiNewPlusButton = new UINewPlusButton();
            var addNewBarButtonFirst = new UIBarButtonItem()
            {
                CustomView = _uiNewPlusButton
            };

            var logoutButton = new UIBarButtonItem()
                .SetHeaderBarButtonItemStyle(Strings.Logout);

            NavigationItem.TitleView = new UILabel()
                .SetHeaderLabelStyle(Strings.AllRequsts);
            NavigationItem.RightBarButtonItem = addNewBarButtonFirst;
            NavigationItem.LeftBarButtonItem = logoutButton;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            VacationsSource = new UITableViewObservablePlainSource(
                View.VacationsTableView,
                _ => VacationItemViewCell.CellId)
            {
                Items = ViewModel.Vacations
            };

            View.VacationsTableView.Source = VacationsSource;
        }

        public override void Bind(BindingSet<HomeViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(VacationsSource)
                .For(v => v.Items)
                .To(vm => vm.Vacations);

            bindingSet.Bind(VacationsSource)
                .For(v => v.RowSelectedBinding())
                .To(vm => vm.VacationSelectedCommand);

            bindingSet.Bind(_uiNewPlusButton)
                .For(v => v.TouchUpInsideBinding())
                .To(vm => vm.VacationSelectedCommand);

            bindingSet.Bind(NavigationItem.LeftBarButtonItem)
                .For(v => v.ClickedBinding())
                .To(vm => vm.LogoutCommand);

            bindingSet.Bind(View.VacationsTableView.RefreshControl)
                .For(v => v.ValueChangedBinding())
                .To(vm => vm.RefreshCommand);

            bindingSet.Bind(View.VacationsTableView.RefreshControl)
                .For(v => v.BeginRefreshingBinding())
                .To(vm => vm.Loading);

            bindingSet.Bind(View.VacationsTableView.RefreshControl)
                .For(v => v.EndRefreshingBinding())
                .To(vm => vm.Loading);
        }
    }
}