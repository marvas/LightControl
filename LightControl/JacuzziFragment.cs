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
    public class JacuzziFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            this.Activity.ActionBar.Title = "Jacuzzi";
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.Jacuzzi, container, false);
        }

        public override void OnResume()
        {
            this.Activity.ActionBar.Title = "Jacuzzi";
            base.OnResume();
        }
    }
}