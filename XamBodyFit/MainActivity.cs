using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;

namespace XamBodyFit
{
    [Activity(Theme = "@style/AppTheme")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            try
            {
                ServerCommunication.GetAuthKey();
            }
            catch (Exception ex)
            {
                Utilities.ToastMessage(this, Utilities.ToastMessageType.EXCEPTION, ex.Message.ToString());
            }
            Button btnFacebookm = FindViewById<Button>(Resource.Id.btnFacebookTemp);
            btnFacebookm.Click += (object sender, EventArgs e) =>
            {
                StartActivity(typeof(LoginActivity));
            };
            Button btnEmail = FindViewById<Button>(Resource.Id.btnEmail);
            btnEmail.Click += (sender, e) =>
            {
                StartActivity(typeof(RegisterActivity));
            };
            Button btnAlready = FindViewById<Button>(Resource.Id.btnAlready);
            btnAlready.Click += (sender, e) =>
            {
                User user = new User();
                var tempUser = user.GetCacheUserInfo();

                if (tempUser.Email == String.Empty || tempUser.Password == String.Empty)
                {
                    Intent intent = new Intent(this, typeof(LoginActivity));
                    this.StartActivity(intent);
                }
                else
                {
                    Intent intent = new Intent(this, typeof(MenuActivity));
                    intent.PutExtra("User", JsonConvert.SerializeObject(user));
                    StartActivity(intent);
                }

            };
        }


    }
}

