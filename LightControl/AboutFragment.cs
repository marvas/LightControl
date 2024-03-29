﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace LightControl
{
    public class AboutFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            this.Activity.ActionBar.Title = "About";
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Custom view for this Fragment
            return inflater.Inflate(Resource.Layout.About, container, false);
        }

        public override void OnResume()
        {
            this.Activity.ActionBar.Title = "About";
            base.OnResume();
        }
    }
}