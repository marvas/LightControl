using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Support.V4.Widget;
using Android.Support.V7.App;

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

            leftItems.Add("First left item");
            leftItems.Add("Second left item");

            //drawerToggle = new ActionBarDrawerToggle (this, drawerLayout, Resource.Drawable.ic_view_headline_black_24dp, Resource.String.ns_menu_close);

            leftAdapter = new ArrayAdapter (this, Android.Resource.Layout.SimpleListItem1, leftItems);
            leftDrawer.Adapter = leftAdapter;

            //drawerLayout.SetDrawerListener(drawerToggle);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
        }
    }
}

