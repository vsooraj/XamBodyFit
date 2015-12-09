

using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
namespace XamBodyFit
{
    [Activity(Theme = "@style/AppTheme")]
    public class MenuActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Menu);

            Button btnActivate = FindViewById<Button>(Resource.Id.btnActivate);
            Button btnTrain = FindViewById<Button>(Resource.Id.btnTrain);
            Button btnRecover = FindViewById<Button>(Resource.Id.btnRecover);
            Button btnFacebookLike = FindViewById<Button>(Resource.Id.btnFacebookLike);
            Button btnWatchUs = FindViewById<Button>(Resource.Id.btnWatchUs);

            btnActivate.Click += (object sender, EventArgs e) =>
            {
                var activity = new Intent(this, typeof(CatalogActivity));
                activity.PutExtra("CategoryId", "1");
                StartActivity(activity);
            };

            btnTrain.Click += (object sender, EventArgs e) =>
            {
                var activity = new Intent(this, typeof(CatalogActivity));
                activity.PutExtra("CategoryId", "2");
                StartActivity(activity);
            };

            btnRecover.Click += (object sender, EventArgs e) =>
            {
                var activity = new Intent(this, typeof(CatalogActivity));
                activity.PutExtra("CategoryId", "3");
                StartActivity(activity);
            };
            btnFacebookLike.Click += (object sender, EventArgs e) =>
            {
                Toast.MakeText(this, "Facebook Like need to implement", ToastLength.Short).Show();
            };

            btnWatchUs.Click += (object sender, EventArgs e) =>
            {
                Toast.MakeText(this, "Watch us need to implement", ToastLength.Short).Show();
            };

        }
        private void Navigate(string navigatorValue)
        {
            var activity = new Intent(this, typeof(CatalogActivity));
            activity.PutExtra("CategoryId", navigatorValue);
            StartActivity(activity);

        }
    }
}