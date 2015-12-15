using Android.App;
using Android.Support.V4.App;
using Android.Support.V4.Widget;

namespace XamBodyFit
{
    public class MyActionBarDrawerToggle : ActionBarDrawerToggle
    {
        Activity _activity;
        public MyActionBarDrawerToggle(Activity activity, DrawerLayout drawerLayout, int imageResource, int openDrawerDesc, int closeDrawerDesc)
            : base(activity, drawerLayout, imageResource, openDrawerDesc, closeDrawerDesc)
        {
            _activity = activity;
        }
        public override void OnDrawerClosed(Android.Views.View drawerView)
        {
            base.OnDrawerClosed(drawerView);
            //_activity.ActionBar.Title = "Drawer layout App";
        }
        public override void OnDrawerOpened(Android.Views.View drawerView)
        {
            base.OnDrawerOpened(drawerView);
            //_activity.ActionBar.Title = "Please Select from List";
        }
        public override void OnDrawerSlide(Android.Views.View drawerView, float slideOffset)
        {
            base.OnDrawerSlide(drawerView, slideOffset);
        }
        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
        }
    }
}