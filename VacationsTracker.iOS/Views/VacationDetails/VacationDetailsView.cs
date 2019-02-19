using System;
using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Resourses;
using VacationsTracker.iOS.Controls;
using VacationsTracker.iOS.Design;
using VacationsTracker.iOS.Views.ActivityIndicator;

namespace VacationsTracker.iOS.Views.VacationDetails
{
    internal class VacationDetailsView : LayoutView
    {
        private FluentLayout _contentViewExpanded;
        private FluentLayout _contentViewCollapsedByToolbar;
        private FluentLayout _toolbarAboveStartPicker;
        private FluentLayout _toolbarAboveEndPicker;
        private FluentLayout _toolbarBottom;
        private FluentLayout _datePickerToolbarExpanded;
        private FluentLayout _datePickerToolbarCollapsed;
        private FluentLayout _datePickerStartCollapsed;
        private FluentLayout _datePickerStartExpanded;
        private FluentLayout _datePickerEndExpanded;
        private FluentLayout _datePickerEndCollapsed;

        public UIView ContentView { get; private set; }

        public UIView VacationsPager { get; private set; }

        public UIPageControl VacationPageControl { get; set; }

        public UIView AboveDateSeparator { get; private set; }

        public LargeDateControl DateBeginView { get; private set; }

        public LargeDateControl DateEndView { get; private set; }

        public UIView BelowDateSeparator { get; private set; }

        public UISegmentedControl StatusSegmentedControl { get; private set; }

        public UIToolbar DatePickerToolbar { get; private set; }

        public UIDatePicker StartDatePicker { get; private set; }

        public UIDatePicker EndDatePicker { get; private set; }

        public ActivityIndicatorView ActivityIndicator { get; private set; }

        public void HideDatePickers()
        {
            _contentViewExpanded.Active = true;
            _contentViewCollapsedByToolbar.Active = false;

            _toolbarAboveStartPicker.Active = false;
            _toolbarAboveEndPicker.Active = false;
            _toolbarBottom.Active = true;

            _datePickerToolbarExpanded.Active = false;
            _datePickerToolbarCollapsed.Active = true;

            _datePickerStartExpanded.Active = false;
            _datePickerStartCollapsed.Active = true;

            _datePickerEndExpanded.Active = false;
            _datePickerEndCollapsed.Active = true;

            UIView.Animate(0.3, LayoutIfNeeded);
        }

        public void ShowStartDatePicker()
        {
            HideDatePickers();

            _contentViewExpanded.Active = false;
            _contentViewCollapsedByToolbar.Active = true;

            _toolbarBottom.Active = false;
            _toolbarAboveStartPicker.Active = true;

            _datePickerToolbarCollapsed.Active = false;
            _datePickerToolbarExpanded.Active = true;

            _datePickerStartCollapsed.Active = false;
            _datePickerStartExpanded.Active = true;

            UIView.Animate(0.3, LayoutIfNeeded);
        }

        public void ShowEndDatePicker()
        {
            HideDatePickers();

            _contentViewExpanded.Active = false;
            _contentViewCollapsedByToolbar.Active = true;

            _toolbarBottom.Active = false;
            _toolbarAboveEndPicker.Active = true;

            _datePickerToolbarCollapsed.Active = false;
            _datePickerToolbarExpanded.Active = true;

            _datePickerEndCollapsed.Active = false;
            _datePickerEndExpanded.Active = true;

            UIView.Animate(0.3, LayoutIfNeeded);
        }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            ContentView = new UIView {BackgroundColor = AppColors.ContentPrimary };

            VacationsPager = new UIView();
            VacationPageControl = new UIPageControl
            {
                Pages = Enum.GetValues(typeof(VacationType)).Length, PageIndicatorTintColor = AppColors.TextBody,
                CurrentPageIndicatorTintColor = AppColors.TextPrimary
            };

            AboveDateSeparator = new UIView().SetSeparatorStyle();
            DateBeginView = new LargeDateControl(AppColors.TextPrimary);
            DateEndView = new LargeDateControl(AppColors.TextSecondary);
            BelowDateSeparator = new UIView().SetSeparatorStyle();
            StatusSegmentedControl = new UISegmentedControl(Strings.Approved, Strings.Closed)
            {
                TintColor = AppColors.TextSecondary
            };

            StartDatePicker = new UIDatePicker {Mode = UIDatePickerMode.Date};

            EndDatePicker = new UIDatePicker {Mode = UIDatePickerMode.Date};

            DatePickerToolbar = new UIToolbar
            {
                BarStyle = UIBarStyle.Default, Translucent = true, TintColor = AppColors.TextPrimary
            };

            var doneButton = new UIBarButtonItem()
            {
                Title = Strings.Done,
                Style = UIBarButtonItemStyle.Plain,
            };
            doneButton.ClickedWeakSubscribe((sender, args) => HideDatePickers());
            var space = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);

            DatePickerToolbar.SetItems(new[] { space, doneButton }, false);
            DatePickerToolbar.UserInteractionEnabled = true;

            ActivityIndicator = new ActivityIndicatorView(80, 1);
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(ContentView
                    .AddLayoutSubview(VacationsPager)
                    .AddLayoutSubview(VacationPageControl)
                    .AddLayoutSubview(AboveDateSeparator)
                    .AddLayoutSubview(DateBeginView)
                    .AddLayoutSubview(DateEndView)
                    .AddLayoutSubview(BelowDateSeparator)
                    .AddLayoutSubview(StatusSegmentedControl))
                .AddLayoutSubview(DatePickerToolbar)
                .AddLayoutSubview(StartDatePicker)
                .AddLayoutSubview(EndDatePicker)
                .AddLayoutSubview(ActivityIndicator);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            DateBeginView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            DateEndView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _contentViewExpanded = ContentView.AtBottomOf(this);
            _contentViewCollapsedByToolbar = ContentView.Above(DatePickerToolbar);
            _contentViewCollapsedByToolbar.Active = false;

            this.AddConstraints(
                ContentView.FullWidthOf(this));

            this.AddConstraints(
                ContentView.AtTopOf(this),
                _contentViewExpanded,
                _contentViewCollapsedByToolbar);

            this.AddConstraints(
                VacationsPager.AtTopOf(ContentView, AppDimens.Inset3x),
                VacationsPager.WithSameCenterX(ContentView),
                VacationsPager.WithRelativeHeight(ContentView, 0.3f),
                VacationsPager.WithSameWidth(ContentView));

            this.AddConstraints(
                VacationPageControl.WithSameCenterX(ContentView),
                VacationPageControl.Below(VacationsPager, AppDimens.Inset1x),
                VacationPageControl.WithSameWidth(ContentView),
                VacationPageControl.Height().EqualTo(AppDimens.Inset2x));

            this.AddConstraints(
                AboveDateSeparator.AtLeftOf(ContentView),
                AboveDateSeparator.Below(VacationPageControl, AppDimens.Inset1x),
                AboveDateSeparator.AtRightOf(ContentView),
                AboveDateSeparator.Height().EqualTo(AppDimens.SeparatorSize));

            this.AddConstraints(
                DateBeginView.Below(AboveDateSeparator, AppDimens.Inset1x),
                DateBeginView.AtLeftOf(ContentView),
                DateBeginView.WithRelativeWidth(ContentView, 0.5f),
                DateBeginView.Height().EqualTo(AppDimens.Inset9x));

            this.AddConstraints(
                DateEndView.ToRightOf(DateBeginView),
                DateEndView.Below(AboveDateSeparator),
                DateEndView.WithRelativeWidth(ContentView, 0.5f),
                DateEndView.Height().EqualTo(AppDimens.Inset9x));

            this.AddConstraints(
                BelowDateSeparator.AtLeftOf(ContentView),
                BelowDateSeparator.Below(DateBeginView, AppDimens.Inset1x),
                BelowDateSeparator.AtRightOf(ContentView),
                BelowDateSeparator.Height().EqualTo(AppDimens.SeparatorSize));

            this.AddConstraints(
                StatusSegmentedControl.Below(BelowDateSeparator, AppDimens.Inset4x),
                StatusSegmentedControl.WithSameCenterX(ContentView));

            _toolbarBottom = DatePickerToolbar.AtBottomOf(this);
            _toolbarAboveStartPicker = DatePickerToolbar.Above(StartDatePicker);
            _toolbarAboveStartPicker.Active = false;
            _toolbarAboveEndPicker = DatePickerToolbar.Above(EndDatePicker);
            _toolbarAboveEndPicker.Active = false;

            _datePickerToolbarCollapsed = DatePickerToolbar.Height().EqualTo(0);
            _datePickerToolbarExpanded = DatePickerToolbar.Height().EqualTo(AppDimens.ToolbarSize);
            _datePickerToolbarExpanded.Active = false;

            this.AddConstraints(
                DatePickerToolbar.AtLeftOf(this),
                DatePickerToolbar.AtRightOf(this),
                _toolbarBottom,
                _toolbarAboveStartPicker,
                _toolbarAboveEndPicker,
                _datePickerToolbarCollapsed,
                _datePickerToolbarExpanded);

            _datePickerStartCollapsed = StartDatePicker.Height().EqualTo(0);
            _datePickerStartExpanded = StartDatePicker.Height().EqualTo(AppDimens.DatePickerSize);
            _datePickerStartExpanded.Active = false;

            this.AddConstraints(
                StartDatePicker.AtLeftOf(this),
                StartDatePicker.AtBottomOf(this),
                StartDatePicker.AtRightOf(this),
                _datePickerStartCollapsed,
                _datePickerStartExpanded);

            _datePickerEndCollapsed = EndDatePicker.Height().EqualTo(0);
            _datePickerEndExpanded = EndDatePicker.Height().EqualTo(AppDimens.DatePickerSize);
            _datePickerEndExpanded.Active = false;

            this.AddConstraints(
                EndDatePicker.AtLeftOf(this),
                EndDatePicker.AtBottomOf(this),
                EndDatePicker.AtRightOf(this),
                _datePickerEndCollapsed,
                _datePickerEndExpanded);

            this.AddConstraints(
                ActivityIndicator.WithSameCenterX(this),
                ActivityIndicator.WithSameCenterY(this));

        }
    }
}