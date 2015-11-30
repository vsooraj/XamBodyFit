

using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
namespace XamBodyFit
{
    [Activity()]
    public class MenuActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Button btnActivate, btnTrain, btnRecover, btnFacebookLike, btnWatchUs;
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Menu);

            btnActivate = FindViewById<Button>(Resource.Id.btnActivate);
            btnTrain = FindViewById<Button>(Resource.Id.btnTrain);
            btnRecover = FindViewById<Button>(Resource.Id.btnRecover);
            btnFacebookLike = FindViewById<Button>(Resource.Id.btnFacebookLike);
            btnWatchUs = FindViewById<Button>(Resource.Id.btnWatchUs);

            btnActivate.Click += (object sender, EventArgs e) =>
            {
                var activity = new Intent(this, typeof(CatalogActivity));
                activity.PutExtra("MyData", "Activate");
                StartActivity(activity);
            };

            btnTrain.Click += (object sender, EventArgs e) =>
            {
                var activity = new Intent(this, typeof(CatalogActivity));
                activity.PutExtra("MyData", "Train");
                StartActivity(activity);
            };

            btnRecover.Click += (object sender, EventArgs e) =>
            {
                var activity = new Intent(this, typeof(CatalogActivity));
                activity.PutExtra("MyData", "Recover");
                StartActivity(activity);
            };
            btnFacebookLike.Click += (object sender, EventArgs e) =>
            {
                StartActivity(typeof(CatalogActivity));
            };

            btnWatchUs.Click += (object sender, EventArgs e) =>
            {
                StartActivity(typeof(CatalogActivity));
            };

        }
    }
}