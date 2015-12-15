

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

            Button mbtnActivate = FindViewById<Button>(Resource.Id.btnActivatem);
            Button mbtnTrain = FindViewById<Button>(Resource.Id.btnTrainm);
            Button mbtnRecover = FindViewById<Button>(Resource.Id.btnRecoverm);
            Button btnFacebookLike = FindViewById<Button>(Resource.Id.btnFacebookLike);
            Button btnWatchUs = FindViewById<Button>(Resource.Id.btnWatchUs);
            mbtnActivate.Click += btnActivate_Click;
            mbtnTrain.Click += btnTrain_Click;
            mbtnRecover.Click += btnRecover_Click;
            btnFacebookLike.Click += btnFacebookLike_Click;

        }

        private void btnFacebookLike_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Facebook Like need to implement", ToastLength.Short).Show();
        }

        private void btnWatchUs_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Watch us on Youtube", ToastLength.Short).Show();
            var uri = Android.Net.Uri.Parse("https://www.youtube.com/playlist?list=PLF4JrUN5fmESmlWap4jWuQgvcUbA222gC");
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException(); var activity = new Intent(this, typeof(CatalogActivity));
            activity.PutExtra("CategoryId", "3");
            StartActivity(activity);
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            var activity = new Intent(this, typeof(CatalogActivity));
            activity.PutExtra("CategoryId", "2");
            StartActivity(activity);
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            var activity = new Intent(this, typeof(CatalogActivity));
            activity.PutExtra("CategoryId", "1");
            StartActivity(activity);
        }


        private void Navigate(string navigatorValue)
        {
            var activity = new Intent(this, typeof(CatalogActivity));
            activity.PutExtra("CategoryId", navigatorValue);
            StartActivity(activity);

        }
    }
}