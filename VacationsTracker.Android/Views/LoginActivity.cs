﻿using Android.App;
using Android.OS;
using FlexiMvvm.Views.V7;
using VacationsTracker.Core.Presentation.ViewModels.Login;

namespace VacationsTracker.Android.Views
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : FlxAppCompatActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);
        }
    }
}