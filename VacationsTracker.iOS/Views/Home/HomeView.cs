using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Design;
using VacationsTracker.iOS.Views.Home.VacationsTable;

namespace VacationsTracker.iOS.Views.Home
{
    internal class HomeView : LayoutView
    {
        public UITableView VacationsTableView { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();
            
            BackgroundColor = AppColors.ContentPrimary;

            VacationsTableView = new UITableView();
            VacationsTableView.RefreshControl = new UIRefreshControl();
            VacationsTableView.RegisterClassForCellReuse(
                typeof(VacationItemViewCell),
                VacationItemViewCell.CellId);
            VacationsTableView.AllowsSelection = true;
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(VacationsTableView);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(VacationsTableView.FullSizeOf(this));
        }
    }
}