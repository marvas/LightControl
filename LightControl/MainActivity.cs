using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;

namespace LightControl
{
    [Activity(Label = "LightControl", MainLauncher = true, Icon = "@drawable/icon")]
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

            leftItems.Add("Todo");
            leftItems.Add("Weather");
            leftItems.Add("Outdoor lighting");
            leftItems.Add("Jacuzzi");
            leftItems.Add("About");

            drawerToggle = new ActionBarDrawerToggle (this, drawerLayout, Resource.String.open_drawer, Resource.String.close_drawer);

            leftAdapter = new ArrayAdapter (this, Android.Resource.Layout.SimpleListItem1, leftItems);
            leftDrawer.Adapter = leftAdapter;

            drawerLayout.AddDrawerListener(drawerToggle);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
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
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}

