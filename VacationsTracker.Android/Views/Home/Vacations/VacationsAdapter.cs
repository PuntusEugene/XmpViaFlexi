using Android.Support.V7.Widget;
using Android.Views;
using FlexiMvvm.Collections;
using VacationsTracker.Core.Presentation.ViewModels.Home;

namespace VacationsTracker.Android.Views.Home.Vacations
{
    internal class VacationsAdapter : RecyclerViewObservablePlainAdapterBase
    {
        public VacationsAdapter(RecyclerView recyclerView, HomeViewModel itemsContext)
            : base(recyclerView)
        {
            ItemsContext = itemsContext;
        }

        protected override RecyclerViewObservableViewHolder OnCreateItemViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_vacation_item, parent, false);

            return new VacationItemCellViewHolder(view);
        }

        protected override RecyclerViewObservableViewHolder OnCreateHeaderViewHolder(ViewGroup parent)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_vacation_header, parent, false);

            return new VacationHeaderCellViewHolder(view);
        }
    }
}