using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;

namespace LightControl
{
    [Activity(Label = "LightControl")]
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
            // Get position of click
            var position = e.Position;
            switch (position)
            {
                // Information
                case 0:
                    StartActivity(typeof(InformationActivity));
                    break;
                // Weather
                case 1:
                    StartActivity(typeof(WeatherActivity));
                    break;
                // Outdoor lighting
                case 2:
                    StartActivity(typeof(OutdoorLightsActivity));
                    break;
                // Jacuzzi
                case 3:
                    StartActivity(typeof(JacuzziActivity));
                    break;
                // POI
                case 4:
                    StartActivity(typeof(PoiActivity));
                    break;
                // About
                case 5:
                    StartActivity(typeof(AboutActivity));
                    break;
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

