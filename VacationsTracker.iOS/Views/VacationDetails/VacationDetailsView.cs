using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Resourses;
using VacationsTracker.iOS.Design;
using VacationsTracker.iOS.Views.Home.VacationsTable;

namespace VacationsTracker.iOS.Views.VacationDetails
{
    internal class VacationDetailsView : LayoutView
    {
        public UIPageControl TypePageControl { get; private set; }

        public UIView DateBeginView { get; private set; }

        public UIView DateEndView { get; private set; }

        public UISegmentedControl StatusSegmentedControl { get; private set; }

        public UIDatePicker DatePicker { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = AppColors.Header;

            TypePageControl = new UIPageControl();
            DateBeginView = new UIView();
            DateEndView = new UIView();
            StatusSegmentedControl = new UISegmentedControl(VacationResource.Approved, VacationResource.Closed);
            StatusSegmentedControl.TintColor = AppColors.Secondary;

            DatePicker = new UIDatePicker();
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(TypePageControl)
                .AddLayoutSubview(DateBeginView)
                .AddLayoutSubview(StatusSegmentedControl);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                TypePageControl.AtLeftOf(this),
                TypePageControl.AtTopOf(this),
                TypePageControl.AtRightOf(this),
                TypePageControl.WithRelativeHeight(this, 0.35f));

            this.AddConstraints(
                DateBeginView.Below(TypePageControl, AppDimens.Inset1x),
                DateBeginView.WithSameLeft(TypePageControl),
                DateBeginView.WithRelativeWidth(TypePageControl, 0.5f),
                DateBeginView.WithRelativeHeight(this, 0.25f));

            this.AddConstraints(
                DateEndView.AtLeftOf(DateBeginView),
                DateEndView.WithSameWidth(DateBeginView),
                DateEndView.WithSameHeight(DateBeginView));

            this.AddConstraints(
                StatusSegmentedControl.Below(DateBeginView, AppDimens.Inset4x),
                StatusSegmentedControl.WithSameCenterX(this));
        }
    }
}