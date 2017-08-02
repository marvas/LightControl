using System;
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
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace LightControl
{
    public class PoiFragment : Fragment, IOnMapReadyCallback
    {
        private GoogleMap gMap;
        MapView mapView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            this.Activity.ActionBar.Title = "Points of interest";
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View inflatedView = inflater.Inflate(Resource.Layout.Poi, container, false);

            mapView = (MapView)inflatedView.FindViewById(Resource.Id.map);
            mapView.OnCreate(savedInstanceState);
            mapView.OnResume();

            try
            {
                MapsInitializer.Initialize(Activity.ApplicationContext);
            }
            catch (Exception e)
            {
                //IMPLEMENT
            }
            
            mapView.GetMapAsync(this);

            return inflatedView;
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            gMap = googleMap;
        }

        public override void OnResume()
        {
            this.Activity.ActionBar.Title = "Points of interest";
            base.OnResume();
            mapView.OnResume();
        }

        public override void OnPause()
        {
            base.OnPause();
            mapView.OnPause();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            mapView.OnDestroy();
        }

        public override void OnLowMemory()
        {
            base.OnLowMemory();
            mapView.OnLowMemory();
        }
    }
}