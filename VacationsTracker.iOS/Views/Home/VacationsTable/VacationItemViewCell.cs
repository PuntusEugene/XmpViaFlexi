using System;
using Cirrious.FluentLayouts.Touch;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.iOS.ValueConverters;

namespace VacationsTracker.iOS.Views.Home.VacationsTable
{
    internal class VacationItemViewCell
        : UITableViewBindableItemCell<HomeViewModel, VacationItemViewModel>
    {

        public static string CellId { get; } = nameof(VacationItemViewCell);
        private VacationItemView View { get; set; }

        protected internal VacationItemViewCell(IntPtr handle)
            : base(handle)
        {
        }

        public override void LoadView()
        {
            View = new VacationItemView();

            ContentView.NotNull().AddSubview(View);
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ContentView.AddConstraints(View.FullSizeOf(ContentView));
        }

        public override void Bind(BindingSet<VacationItemViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View)
                .For(v => v.VacationTypeImageView.Image)
                .To(vm => vm.VacationType)
                .WithConvertion<VacationTypeToImageValueConverter>();

            bindingSet.Bind(View)
                .For(v => v.VacationDurationLabel.Text)
                .To(vm => vm.Duration)
                .WithConvertion<DurationToStringValueConverter>();

            bindingSet.Bind(View)
                .For(v => v.VacationTypeLabel.Text)
                .To(vm => vm.VacationType)
                .WithConvertion<VacationTypeToStringValueConverter>();
            
            bindingSet.Bind(View)
                .For(v => v.VacationStatusLabel.Text)
                .To(vm => vm.VacationStatus)
                .WithConvertion<VacationStatusToStringValueConverter>();
        }
    }
}