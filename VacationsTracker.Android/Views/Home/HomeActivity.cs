using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V7;
using VacationsTracker.Android.Bindings;
using VacationsTracker.Android.Views.Home.Vacations;
using VacationsTracker.Core.Presentation.ViewModels.Home;

namespace VacationsTracker.Android.Views.Home
{
    [Activity(Label = "", Theme = "@style/AppTheme.Light.NoActionBar")]
    internal class HomeActivity : FlxBindableAppCompatActivity<HomeViewModel>
    {
        private HomeActivityViewHolder ViewHolder { get; set; }

        private VacationsAdapter VacationsAdapter { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_home);

            ViewHolder = new HomeActivityViewHolder(this);

            VacationsAdapter = new VacationsAdapter(
                ViewHolder.VacationsRecyclerView,
                ViewModel)
            {
                Items = ViewModel.Vacations
            };

            ViewHolder.VacationsRecyclerView.SetAdapter(VacationsAdapter);
            ViewHolder.VacationsRecyclerView.SetLayoutManager(new LinearLayoutManager(this, 1, false));

            SetSupportActionBar(ViewHolder.HomeToolbar);
        }

        public override void Bind(BindingSet<HomeViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(VacationsAdapter)
                .For(v => v.ItemClickedBinding())
                .To(vm => vm.VacationSelectedCommand);

            bindingSet.Bind(ViewHolder.LogoutButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.LogoutCommand);

            bindingSet.Bind(ViewHolder.AddVacationButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.VacationSelectedCommand);

            bindingSet.Bind(ViewHolder.SwipeRefresh)
                .For(v => v.RefreshingBinding())
                .To(vm => vm.Loading)
                .TwoWay();

            bindingSet.Bind(ViewHolder.SwipeRefresh)
                .For(v => v.RefreshBinding())
                .To(vm => vm.RefreshCommand);
        }
    }
}