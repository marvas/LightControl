﻿using Android.App;
using Android.OS;
using System;

namespace LightControl
{
    [Activity(MainLauncher = true, NoHistory = true, Label = "SplashScreen", Theme = "@android:style/Theme.NoTitleBar", Icon = "@drawable/Icon")]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set splash screen as current view
            SetContentView(Resource.Layout.Splash);

            Handler handler = new Handler();
            // Action to start main activity
            Action startMainActivity = () =>
            {
                StartActivity(typeof(MainActivity));
            };

            // Delays start of main activity by set amount seconds
            handler.PostDelayed(startMainActivity, 5000);
        }
    }
}