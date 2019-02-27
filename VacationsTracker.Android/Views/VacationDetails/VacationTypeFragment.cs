using Android.OS;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V4;
using VacationsTracker.Android.Bindings;
using VacationsTracker.Android.ValueConverters;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails.VacationPager;
using LayoutInflater = Android.Views.LayoutInflater;

namespace VacationsTracker.Android.Views.VacationDetails
{
    public class VacationTypeFragment : FlxBindableFragment<VacationTypePagerViewModel>
    {
        private VacationTypeFragmentViewHolder ViewHolder { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // TODO inflate view
            var view = LayoutInflater.From(Context).Inflate(Resource.Layout.fragment_vacation_type, null, false);

            ViewHolder = new VacationTypeFragmentViewHolder(view);
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