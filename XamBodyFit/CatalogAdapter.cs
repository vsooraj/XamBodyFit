
using System.Collections.Generic;
using System.Net;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace XamBodyFit
{
    class CatalogAdapter : BaseAdapter<Video>
    {
        List<Video> mItems;
        private Context mContext;
        public CatalogAdapter(Context context, List<Video> items)
        {
            mItems = items;
            mContext = context;
        }
        public override Video this[int position]
        {
            get { return mItems[position]; }
        }

        public override int Count
        {
            get { return mItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(mContext).Inflate(Resource.Layout.catalog_view, null, false);
            }
            //ImageView imgViewThumbnail = view.FindViewById<ImageView>(Resource.Id.imgViewThumbnail);
            //var uri = Android.Net.Uri.Parse(mItems[position].Thumbnail);
            ////imgViewThumbnail.SetImageURI(uri);
            //imgViewThumbnail.SetImageResource(Resource.Drawable.icon);

            TextView txtTitle = view.FindViewById<TextView>(Resource.Id.txtTitle);
            txtTitle.Text = mItems[position].Title;

            TextView txtDescription = view.FindViewById<TextView>(Resource.Id.txtDescription);
            txtDescription.Text = mItems[position].Description;

            TextView txtDuration = view.FindViewById<TextView>(Resource.Id.txtDuration);
            txtDuration.Text = mItems[position].Duration.ToString();
            return view;
        }
        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
}