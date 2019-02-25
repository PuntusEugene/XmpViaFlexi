using Android.Views;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Home;

// ReSharper disable once CheckNamespace
namespace VacationsTracker.Android.Views
{
    public partial class VacationHeaderCellViewHolder
        : RecyclerViewBindableHeaderFooterViewHolder<HomeViewModel>
    {
        public VacationHeaderCellViewHolder(View itemView) : base(itemView)
        {
        }

        public override void Bind(BindingSet<HomeViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(LastUpdateTime)
                .For(v => v.TextBinding())
                .To(vm => vm.LastUpdateTime)
                .WithConvertion<LastUpdateToStringValueConverter>();
        }
    }
}