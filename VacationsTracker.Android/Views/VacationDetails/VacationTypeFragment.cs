using Android.OS;
using Android.Views;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V4;
using VacationsTracker.Android.Bindings;
using VacationsTracker.Android.ValueConverters;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails.VacationPager;
using LayoutInflater = Android.Views.LayoutInflater;

namespace VacationsTracker.Android.Views.VacationDetails
{
    public class VacationTypeFragment 
        : FlxBindableFragment<VacationTypePagerViewModel, VacationTypePagerParameters>
    {
        private VacationTypeFragmentViewHolder ViewHolder { get; set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_vacation_type, container, false);

            ViewHolder = new VacationTypeFragmentViewHolder(view);

            return view;
        }

        public override void Bind(BindingSet<VacationTypePagerViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ViewHolder.VacationTypeImageView)
                .For(v => v.SetImageResourceBinding())
                .To(vm => vm.VacationType)
                .WithConvertion<VacationTypeToResourceImageValueConverter>();

            bindingSet.Bind(ViewHolder.VacationTypeTextView)
                .For(v => v.TextBinding())
                .To(vm => vm.VacationType)
                .WithConvertion<VacationTypeToStringValueConverter>();
        }
    }
}