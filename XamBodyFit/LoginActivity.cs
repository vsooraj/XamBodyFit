
using Android.App;
using Android.OS;

namespace XamBodyFit
{
    [Activity]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);
        }
    }
}