using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexiMvvm;
using FlexiMvvm.Views;
using Foundation;
using UIKit;
using VacationsTracker.Core.Presentation.ViewModels.Setting;
using VacationsTracker.iOS.Design;

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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
}