using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace XamBodyFit
{
    [Activity(Label = "Main Activity")]
    public class MainActivity : Activity
    {
        private Button btnFacebook, btnEmail, btnAlready;
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            //Facebook
            btnFacebook = FindViewById<Button>(Resource.Id.btnFacebook);
            btnFacebook.Click += (object sender, EventArgs e) =>
            {

                StartActivity(typeof(LoginActivity));
            };
            //Register with Email
            btnEmail = FindViewById<Button>(Resource.Id.btnEmail);
            btnEmail.Click += new EventHandler(btnEmail_Click);

            //Already on BODYFIT
            btnAlready = FindViewById<Button>(Resource.Id.btnAlready);
            btnAlready.Click += new EventHandler(btnAlready_Click);

        }
        void btnEmail_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(RegisterActivity));
        }

        void btnAlready_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(LoginActivity));
        }
    }
}

