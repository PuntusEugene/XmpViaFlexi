using Android.App;
using Android.OS;
using Android.Support.V4.Content;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V7;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails;

namespace VacationsTracker.Android.Views.VacationDetails
{
    [Activity(Label = "", Theme = "@style/AppTheme.Light.NoActionBar")]
    internal class VacationDetailActivity : FlxBindableAppCompatActivity<VacationDetailsViewModel, VacationDetailsParameters>
    {
        private DetailActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_detail);

            ViewHolder = new DetailActivityViewHolder(this);

            var primaryColor = ContextCompat.GetColorStateList(this.ApplicationContext, Resource.Color.colorPrimary);
            ViewHolder.DateFromViewHolder.DayOfDate.SetTextColor(primaryColor);
            ViewHolder.DateFromViewHolder.MonthOfDate.SetTextColor(primaryColor);
            ViewHolder.DateFromViewHolder.YearOfDate.SetTextColor(primaryColor);

            var secondaryColor = ContextCompat.GetColorStateList(this.ApplicationContext, Resource.Color.colorSecondary);
            ViewHolder.DateToViewHolder.DayOfDate.SetTextColor(primaryColor);
            ViewHolder.DateToViewHolder.MonthOfDate.SetTextColor(primaryColor);
            ViewHolder.DateToViewHolder.YearOfDate.SetTextColor(primaryColor);

            SetSupportActionBar(ViewHolder.HomeToolbar);
        }

        public override void Bind(BindingSet<VacationDetailsViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ViewHolder.BackButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.BackToHomeCommand);

            bindingSet.Bind(ViewHolder.SaveButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.BackToHomeCommand);


            bindingSet.Bind(ViewHolder.FabSaveButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.BackToHomeCommand);

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

            bindingSet.Bind(ViewHolder.FabSaveButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.BackToHomeCommand);
        }
    }
}