using System.Diagnostics.CodeAnalysis;
using Android.OS;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V7;
using VacationsTracker.Core.Presentation.ViewModels.VacationDetails;

namespace VacationsTracker.Android.Views.VacationDetails
{
    [SuppressMessage("ReSharper", "RedundantOverriddenMember")]
    internal class VacationDetailActivity : FlxBindableAppCompatActivity<VacationDetailsViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void Bind(BindingSet<VacationDetailsViewModel> bindingSet)
        {
            base.Bind(bindingSet);
        }
    }
}