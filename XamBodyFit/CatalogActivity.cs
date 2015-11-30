
using Android.App;
using Android.OS;
using Android.Widget;

namespace XamBodyFit
{
    [Activity(Label = "Here is the Catalog ")]
    public class CatalogActivity : Activity
    {
        ListView mListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.catalog);
            string text = Intent.GetStringExtra("MyData") ?? "Data not available";
            Toast.MakeText(this, text, ToastLength.Short).Show();
        }
    }
}