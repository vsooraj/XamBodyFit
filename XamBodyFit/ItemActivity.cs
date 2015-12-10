
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace XamBodyFit
{
    [Activity(Theme = "@style/AppTheme")]
    public class ItemActivity : Activity
    {
        int categoryId;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.item);
            var videoView = FindViewById<VideoView>(Resource.Id.SampleVideoView);
            var back = FindViewById<Button>(Resource.Id.btnBack);
            var stop = FindViewById<Button>(Resource.Id.btnStop);
            var play = FindViewById<Button>(Resource.Id.btnPlay);
            string filePath = Intent.GetStringExtra("MyVideo") ?? "Video not available";
            categoryId = int.Parse(Intent.GetStringExtra("CategoryId") ?? "0");
            LaunchVideo(videoView, filePath);

            stop.Click += delegate
            {
                if (videoView.IsPlaying)
                {
                    videoView.StopPlayback();
                }
            };
            play.Click += delegate
            {
                if (videoView.IsPlaying)
                {
                    videoView.StopPlayback();
                    videoView.Start();
                }

            };

            back.Click += back_Click;
        }

        void back_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CatalogActivity));
            intent.PutExtra("CategoryId", categoryId);
            StartActivity(intent);
        }

        private static void LaunchVideo(VideoView videoView, string filePath)
        {
            bool tempVideo;
            if (string.IsNullOrEmpty(filePath))
            {
                tempVideo = true;
                if (tempVideo)
                {
                    videoView.SetBackgroundColor(Android.Graphics.Color.Red);
                    filePath = "http://www.webestools.com/page/media/videoTag/BigBuckBunny.mp4";
                }
            }
            using (var uri = Android.Net.Uri.Parse(filePath))
            {

                videoView.SetVideoURI(uri);
                videoView.Visibility = ViewStates.Visible;

                videoView.Start();
            }

        }
    }
}