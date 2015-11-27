using System.Threading;
using Android.App;
using Android.OS;

namespace XamBodyFit
{

    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.splash);
            Thread.Sleep(6000);
            StartActivity(typeof(MainActivity));
        }
       
    }

}