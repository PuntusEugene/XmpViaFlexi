using System;
using Cirrious.FluentLayouts.Touch;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.Views;
using Foundation;
using UIKit;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails.VacationPager;
using VacationsTracker.Core.Resourses;
using VacationsTracker.iOS.Design;
using VacationsTracker.iOS.ValueConverters;
using VacationsTracker.iOS.Views.VacationDetails.VacationsPager;

namespace VacationsTracker.iOS.Views.VacationDetails
{
    internal class VacationDetailsViewController : FlxBindableViewController<VacationDetailsViewModel, VacationDetailsParameters>
    {
        private UIButton _backButton;

        public new VacationDetailsView View
        {
            get => (VacationDetailsView)base.View.NotNull();
            set => base.View = value;
        }

        private UIPageViewController VacationsPageViewController { get; set; }

        private UIPageViewControllerObservableDataSource VacationsDataSource { get; set; }

        public VacationDetailsViewController(VacationDetailsParameters parameters) : base(parameters)
        {
        }

        public override void LoadView()
        {
            View = new VacationDetailsView();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var backImageView = new UIImageView() { Image = AppImages.LeftArrowWhite, TintColor = AppColors.TextHeadline};
            var backLabel = new UILabel().SetHeaderLabelByBarButtonStyle(Strings.BackHeader);

            _backButton = new UIButton();
            _backButton.AddLayoutSubview(backImageView)
                .AddLayoutSubview(backLabel);

            _backButton.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            _backButton.AddConstraints(backImageView.AtLeftOf(_backButton),
                backImageView.WithSameCenterY(_backButton),
                backImageView.Width().EqualTo(AppDimens.Inset3x),
                backImageView.Height().EqualTo(AppDimens.Inset3x));

            _backButton.AddConstraints(backLabel.ToRightOf(backImageView),
                backLabel.WithSameCenterY(_backButton),
                backLabel.AtRightOf(_backButton));

            NavigationItem.LeftBarButtonItem = new UIBarButtonItem {CustomView = _backButton};

            NavigationItem.RightBarButtonItem = new UIBarButtonItem()
                .SetHeaderBarButtonItemStyle(Strings.Save);

            NavigationItem.TitleView = new UILabel()
                .SetHeaderLabelStyle(Strings.DetailsViewTitle);

            VacationsPageViewController = new UIPageViewController(
                UIPageViewControllerTransitionStyle.Scroll,
                UIPageViewControllerNavigationOrientation.Horizontal);

            VacationsDataSource = new UIPageViewControllerObservableDataSource(
                VacationsPageViewController,
                PagerFactory);

            this.AddChildViewControllerAndView(VacationsPageViewController, View.VacationsPager);

            VacationsPageViewController.DataSource = VacationsDataSource;

            VacationsDataSource.CurrentItemIndexChanged +=
                (sender, args) => View.VacationPageControl.CurrentPage = args.Index;

            var tapGestureStart = new UITapGestureRecognizer(() => { View.ShowStartDatePicker(); });
            View.DateBeginView.AddGestureRecognizer(tapGestureStart);

            var tapGestureEnd = new UITapGestureRecognizer(() => { View.ShowEndDatePicker(); });
            View.DateEndView.AddGestureRecognizer(tapGestureEnd);

            var tapGestureCollapse = new UITapGestureRecognizer(() => { View.HideDatePickers(); });
            View.ContentView.AddGestureRecognizer(tapGestureCollapse);
        }

        public override void Bind(BindingSet<VacationDetailsViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(_backButton)
                .For(v => v.TouchUpInsideBinding())
                .To(vm => vm.BackToHomeCommand);

            bindingSet.Bind(NavigationItem.LeftBarButtonItem)
                .For(v => v.ClickedBinding())
                .To(vm => vm.BackToHomeCommand);

            bindingSet.Bind(NavigationItem.RightBarButtonItem)
                .For(v => v.ClickedBinding())
                .To(vm => vm.SaveVacationCommand);

            bindingSet.Bind(VacationsDataSource)
                .For(v => v.Items)
                .To(vm => vm.VacationTypes);

            bindingSet.Bind(VacationsDataSource)
                .For(v => v.CurrentItemIndexAndCurrentItemIndexChangedBinding())
                .To(vm => vm.VacationType)
                .WithConvertion<VacationTypeToIntValueConverter>();

            bindingSet.Bind(View.DateBeginView.DayOfDateLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.DateBegin)
                .WithConvertion<DayOfDateToStringValueConverter>();

            bindingSet.Bind(View.DateBeginView.MonthOfDateLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.DateBegin)
                .WithConvertion<MonthOfDateToStringValueConverter>();

            bindingSet.Bind(View.DateBeginView.YearOfDateLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.DateBegin)
                .WithConvertion<YearOfDateToStringValueConverter>();

            bindingSet.Bind(View.DateEndView.DayOfDateLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.DateEnd)
                .WithConvertion<DayOfDateToStringValueConverter>();

            bindingSet.Bind(View.DateEndView.MonthOfDateLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.DateEnd)
                .WithConvertion<MonthOfDateToStringValueConverter>();

            bindingSet.Bind(View.DateEndView.YearOfDateLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.DateEnd)
                .WithConvertion<YearOfDateToStringValueConverter>();

            bindingSet.Bind(View.StatusSegmentedControl)
                .For(v => v.SelectedSegmentAndValueChangedBinding())
                .To(vm => vm.VacationStatus)
                .WithConvertion<VacationStatusToIntValueConverter>();

            bindingSet.Bind(View.StartDatePicker)
                .For(v => v.DateAndValueChangedBinding())
                .To(vm => vm.DateBegin)
                .TwoWay()
                .WithConvertion<DateToNSDateValueConverter>();

            bindingSet.Bind(View.EndDatePicker)
                .For(v => v.DateAndValueChangedBinding())
                .To(vm => vm.DateEnd)
                .TwoWay()
                .WithConvertion<DateToNSDateValueConverter>();

            bindingSet.Bind(View.ActivityIndicator)
                .For(v => v.Loading)
                .To(vm => vm.Loading);
        }

        private UIViewController PagerFactory(object parameters)
        {
            if (parameters is VacationTypePagerParameters pagerParameters)
            {
                return new VacationTypePagerViewController(pagerParameters);
            }

            throw new ArgumentException(nameof(parameters));
        }
    }
}