using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace XamBodyFit
{
    [Activity]
    public class MainActivity : Activity
    {
        private Button btnFacebook, btnEmail, btnAlready;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            try
            {
                //Get AuthToken using device and store it in AppConfig
                ServerCommunication.GetAuthKey();
            }
            catch (Exception ex)
            {

                Utilities.ToastMessage(this, Utilities.ToastMessageType.EXCEPTION, ex.Message.ToString());
            }

            //Facebook
            btnFacebook = FindViewById<Button>(Resource.Id.btnFacebook);
            btnFacebook.Click += (object sender, EventArgs e) =>
            {
                StartActivity(typeof(LoginActivity));
            };
            //Register with Email
            btnEmail = FindViewById<Button>(Resource.Id.btnEmail);
            btnEmail.Click += (sender, e) =>
            {
                StartActivity(typeof(RegisterActivity));
            };

            //Already on BODYFIT
            btnAlready = FindViewById<Button>(Resource.Id.btnAlready);
            btnAlready.Click += (sender, e) =>
            {
                StartActivity(typeof(LoginActivity));

            };


        }


    }
}

