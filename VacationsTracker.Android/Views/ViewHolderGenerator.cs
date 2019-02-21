﻿// <auto-generated />
// ReSharper disable All
using System;
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;

namespace VacationsTracker.Android.Views
{
    public partial class LoginActivityViewHolder
    {
         private readonly Activity activity;

         private TextInputLayout loginTextInput;
         private TextInputLayout passwordTextInput;
         private Button loginButton;

        public LoginActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public TextInputLayout LoginTextInput =>
            loginTextInput ?? (loginTextInput = activity.FindViewById<TextInputLayout>(Resource.Id.loginTextInput));

        
        public TextInputLayout PasswordTextInput =>
            passwordTextInput ?? (passwordTextInput = activity.FindViewById<TextInputLayout>(Resource.Id.passwordTextInput));

        
        public Button LoginButton =>
            loginButton ?? (loginButton = activity.FindViewById<Button>(Resource.Id.loginButton));
    }

}
// ReSharper restore All
