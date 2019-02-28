using Android.OS;
using Android.Views;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V4;

namespace VacationsTracker.Android.Views.Home
{
    public class SnackBarViewModel : ViewModelBase
    {
        private string _text;

        public string Text
        {
            get => _text;
            set => Set(ref _text, value);
        }
    }

    internal class SnackBarFragment : FlxBindableFragment<SnackBarViewModel>
    {
        private SnackbarFragmentViewHolder ViewHolder { get; set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_snackbar, container, true);

            ViewHolder = new SnackbarFragmentViewHolder(view);

            return view;
        }

        public override void Bind(BindingSet<SnackBarViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ViewHolder.TextSnackbar)
                .For(v => v.TextBinding())
                .To(vm => vm.Text);
        }
    }
}