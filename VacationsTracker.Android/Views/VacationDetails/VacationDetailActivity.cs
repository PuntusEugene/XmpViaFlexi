using System;
using Android.App;
using Android.OS;
using Android.Support.V4.Content;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.Views;
using FlexiMvvm.Views.V7;
using VacationsTracker.Android.ValueConverters;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails.VacationPager;
using Fragment = Android.Support.V4.App.Fragment;

namespace VacationsTracker.Android.Views.VacationDetails
{
    [Activity(Label = "", Theme = "@style/AppTheme.Light.NoActionBar")]
    internal class VacationDetailActivity : FlxBindableAppCompatActivity<VacationDetailsViewModel, VacationDetailsParameters>
    {
        private DetailActivityViewHolder ViewHolder { get; set; }

        private FragmentPagerObservableAdapter Adapter { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_detail);

            ViewHolder = new DetailActivityViewHolder(this);

            var primaryColor = ContextCompat.GetColorStateList(ApplicationContext, Resource.Color.colorPrimary);
            ViewHolder.DateFromViewHolder.DayOfDate.SetTextColor(primaryColor);
            ViewHolder.DateFromViewHolder.MonthOfDate.SetTextColor(primaryColor);
            ViewHolder.DateFromViewHolder.YearOfDate.SetTextColor(primaryColor);

            var secondaryColor = ContextCompat.GetColorStateList(ApplicationContext, Resource.Color.colorSecondary);
            ViewHolder.DateToViewHolder.DayOfDate.SetTextColor(secondaryColor);
            ViewHolder.DateToViewHolder.MonthOfDate.SetTextColor(secondaryColor);
            ViewHolder.DateToViewHolder.YearOfDate.SetTextColor(secondaryColor);

            ViewHolder.DateFromViewHolder.DateFrom.ClickWeakSubscribe(DateFromSelect_OnClick);
            ViewHolder.DateToViewHolder.DateFrom.ClickWeakSubscribe(DateToSelect_OnClick);

            SetPagerAdapter();

            SetSupportActionBar(ViewHolder.HomeToolbar);
            SetTabLayout();
        }

        private void SetTabLayout()
        {
            ViewHolder.TabLayout.SetupWithViewPager(ViewHolder.VacationPager);
        }

        private void SetPagerAdapter()
        {
            Adapter = new FragmentPagerObservableAdapter(SupportFragmentManager, FragmentsFactory)
            {
                Items = ViewModel.VacationTypes
            };

            ViewHolder.VacationPager.Adapter = Adapter;
        }

        public override void Bind(BindingSet<VacationDetailsViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ViewHolder.BackButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.BackToHomeCommand);

            bindingSet.Bind(Adapter)
                .For(v => v.Items)
                .To(vm => vm.VacationTypes);

            bindingSet.Bind(ViewHolder.VacationPager)
                .For(v => v.SetCurrentItemAndPageSelectedBinding())
                .To(vm => vm.VacationType)
                .TwoWay()
                .WithConvertion<VacationTypeToPagerValueConverter>();

            bindingSet.Bind(ViewHolder.SaveButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.SaveVacationCommand);

            bindingSet.Bind(ViewHolder.DateFromViewHolder.DayOfDate)
                .For(v => v.TextBinding())
                .To(vm => vm.DateBegin)
                .WithConvertion<DayOfDateToStringValueConverter>();

            bindingSet.Bind(ViewHolder.DateFromViewHolder.MonthOfDate)
                .For(v => v.TextBinding())
                .To(vm => vm.DateBegin)
                .WithConvertion<MonthOfDateToStringValueConverter>();

            bindingSet.Bind(ViewHolder.DateFromViewHolder.YearOfDate)
                .For(v => v.TextBinding())
                .To(vm => vm.DateBegin)
                .WithConvertion<YearOfDateToStringValueConverter>();

            bindingSet.Bind(ViewHolder.DateToViewHolder.DayOfDate)
                .For(v => v.TextBinding())
                .To(vm => vm.DateEnd)
                .WithConvertion<DayOfDateToStringValueConverter>();

            bindingSet.Bind(ViewHolder.DateToViewHolder.MonthOfDate)
                .For(v => v.TextBinding())
                .To(vm => vm.DateEnd)
                .WithConvertion<MonthOfDateToStringValueConverter>();

            bindingSet.Bind(ViewHolder.DateToViewHolder.YearOfDate)
                .For(v => v.TextBinding())
                .To(vm => vm.DateEnd)
                .WithConvertion<YearOfDateToStringValueConverter>();

            bindingSet.Bind(ViewHolder.StatusRadioGroup)
                .For(v => v.CheckAndCheckedChangeBinding())
                .To(vm => vm.VacationStatus)
                .TwoWay()
                .WithConvertion<VacationStatusToRadioButtonIdValueConverter>();

            bindingSet.Bind(ViewHolder.FabSaveButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.SaveVacationCommand);
        }

        private void DateFromSelect_OnClick(object sender, EventArgs eventArgs)
        {
            var frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                ViewModel.DateBegin = time;
            });
            frag.Show(FragmentManager, string.Empty);
        }

        private void DateToSelect_OnClick(object sender, EventArgs eventArgs)
        {
            var frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                ViewModel.DateEnd = time;
            });
            frag.Show(FragmentManager, string.Empty);
        }

        private Fragment FragmentsFactory(object parameters)
        {
            if (parameters is VacationTypePagerParameters vacationTypePagerParameters)
            {
                var bundle = new Bundle();
                bundle.PutViewModelParameters(vacationTypePagerParameters);

                var fragment = new VacationTypeFragment()
                {
                    Arguments = bundle
                };

                return fragment;
            }

            throw new NotSupportedException(nameof(parameters));

        }
    }
}