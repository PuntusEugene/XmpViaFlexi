using FlexiMvvm;
using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ViewModels.Setting;

namespace VacationsTracker.iOS.Views.Setting
{
    internal class SettingViewController : FlxBindableViewController<SettingViewModel>
    {
        public new SettingView View
        {
            get => (SettingView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new SettingView();
        }
    }
}