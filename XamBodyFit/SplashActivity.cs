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
            Thread.Sleep(4000);
            StartActivity(typeof(MainActivity));
        }

    }

}