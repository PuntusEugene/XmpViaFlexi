using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using FlexiMvvm.Views.V7;
using VacationsTracker.Android.Views.Home.Vacations;
using VacationsTracker.Core.Presentation.ViewModels.Home;

namespace VacationsTracker.Android.Views.Home
{
    [Activity(Label = "All Requests", ClearTaskOnLaunch = true)]
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
        }
    }
}