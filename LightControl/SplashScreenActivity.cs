using Android.App;
using Android.Content.PM;
using Android.OS;
using System;

namespace LightControl
{
    [Activity(MainLauncher = true, NoHistory = true, Label = "SplashScreen", 
        Theme = "@android:style/Theme.NoTitleBar", Icon = "@drawable/Icon", 
        ScreenOrientation = ScreenOrientation.Portrait)]
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

                // Add custom fade in and fade out when switching to main activity
                OverridePendingTransition(Resource.Animation.FadeIn, Resource.Animation.FadeOut);
            };

            // Delays start of main activity by set amount seconds
            handler.PostDelayed(startMainActivity, 3000);
        }
    }
}