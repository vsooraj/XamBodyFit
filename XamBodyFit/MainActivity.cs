using System.Threading;
using Android.App;
using Android.OS;

namespace XamBodyFit
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Thread.Sleep(6000);
            StartActivity(typeof(LoginActivity));


        }
    }
}

