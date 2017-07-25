using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;
using System;

namespace LightControl
{
    [Activity(Label = "Kåfjord")]
    public class MainActivity : Activity
    {
        DrawerLayout drawerLayout;
        List<string> leftItems = new List<string>();
        ArrayAdapter leftAdapter;
        ListView leftDrawer;
        ActionBarDrawerToggle drawerToggle;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            drawerLayout = FindViewById<DrawerLayout> (Resource.Id.leftDrawer);
            leftDrawer = FindViewById<ListView> (Resource.Id.leftListView);

            // Items in the left drawer list
            leftItems.Add("Information");
            leftItems.Add("Weather");
            leftItems.Add("Outdoor lighting");
            leftItems.Add("Jacuzzi");
            leftItems.Add("Points of interest");
            leftItems.Add("About");

            drawerToggle = new ActionBarDrawerToggle (this, drawerLayout, Resource.String.open_drawer, Resource.String.close_drawer);

            leftAdapter = new ArrayAdapter (this, Android.Resource.Layout.SimpleListItem1, leftItems);
            leftDrawer.Adapter = leftAdapter;

            // Add a item click event listener
            leftDrawer.ItemClick += listView_ItemClick;

            drawerLayout.AddDrawerListener(drawerToggle);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
        }

        void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            // Initialize fragment
            Fragment fragment = null;
            // Get position of click
            var position = e.Position;
            switch (position)
            {
                // Information
                case 0:
                    fragment = new InformationFragment();
                    break;
                // Weather
                case 1:
                    fragment = new WeatherFragment();
                    break;
                // Outdoor lighting
                case 2:
                    fragment = new LightsFragment();
                    break;
                // Jacuzzi
                case 3:
                    fragment = new JacuzziFragment();
                    break;
                // POI
                case 4:
                    fragment = new PoiFragment();
                    break;
                // About
                case 5:
                    fragment = new AboutFragment();
                    break;
            }
            // Add fragment to transaction
            if (fragment != null)
            {
                var fragmentTrans = FragmentManager.BeginTransaction();
                fragmentTrans.Replace(Resource.Id.content_frame, fragment);
                fragmentTrans.AddToBackStack(null);
                fragmentTrans.Commit();

                // Close the drawer after navigating to fragment.
                drawerLayout.CloseDrawers();
            }
        }

        public override void OnBackPressed()
        {
            if (FragmentManager.BackStackEntryCount > 1)
            {
                FragmentManager.PopBackStack();
            }
            else
            {
                ActionBar.Title = "Kåfjord";
                base.OnBackPressed();
            }
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            drawerToggle.SyncState();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (drawerToggle.OnOptionsItemSelected(item))
            {
                return true;
;            }
            return base.OnOptionsItemSelected(item);
        }
    }
}

