
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace XamBodyFit
{
    [Activity(Label = "Videos are here.. ")]
    public class ItemActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.item);
            var videoView = FindViewById<VideoView>(Resource.Id.SampleVideoView);
            string filePath = Intent.GetStringExtra("MyVideo") ?? "Video not available";
            filePath = "http://www.webestools.com/page/media/videoTag/BigBuckBunny.mp4";
            var uri = Android.Net.Uri.Parse(filePath);
            videoView.SetVideoURI(uri);
            videoView.Visibility = ViewStates.Visible;
            videoView.Start();
        }
    }
}