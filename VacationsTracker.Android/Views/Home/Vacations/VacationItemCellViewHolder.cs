using Android.Views;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using VacationsTracker.Android.Bindings;
using VacationsTracker.Android.ValueConverters;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Home;

// ReSharper disable once CheckNamespace
namespace VacationsTracker.Android.Views
{
    public partial class VacationItemCellViewHolder
        : RecyclerViewBindableItemViewHolder<HomeViewModel, VacationItemViewModel>
    {
        public VacationItemCellViewHolder(View itemView)
            : base(itemView)
        {
        }

        public override void Bind(BindingSet<VacationItemViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(VacationTypeImageView)
                .For(v => v.SetImageResourceBinding())
                .To(vm => vm.VacationType)
                .WithConvertion<VacationTypeToResourceImageValueConverter>();

            bindingSet.Bind(VacationDurationTextView)
                .For(v => v.TextBinding())
                .To(vm => vm.Duration)
                .WithConvertion<DurationToStringValueConverter>();

            bindingSet.Bind(VacationTypeTextView)
                .For(v => v.TextBinding())
                .To(vm => vm.VacationType)
                .WithConvertion<VacationTypeToStringValueConverter>();

            bindingSet.Bind(VacationStatusTextView)
                .For(v => v.TextBinding())
                .To(vm => vm.VacationStatus)
                .WithConvertion<VacationStatusToStringValueConverter>();
        }
    }
}