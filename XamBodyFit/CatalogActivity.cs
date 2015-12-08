
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Database;
using Android.Net;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;

namespace XamBodyFit
{
    [Activity(Theme = "@style/AppTheme")]
    public class CatalogActivity : Activity
    {
        ListView mListView;
        int categoryId, subcategoryId;
        Response response = new Response();
        List<Video> mItems;
        CatalogResponse catalogResponse;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.catalog);
            mListView = FindViewById<ListView>(Resource.Id.myListView);
            string category = Intent.GetStringExtra("MyData") ?? "Data not available";
            string subCategory = null;
            Toast.MakeText(this, category, ToastLength.Short).Show();
            CatalogStatus status = getVideos(category, subCategory);
            if (status == CatalogStatus.SUCCESS)
            {
                mItems = catalogResponse.Videos;
                CatalogAdapter adapter = new CatalogAdapter(this, mItems);
                mListView.Adapter = adapter;
                mListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
                {
                    var title = mItems[e.Position].Title;
                    Utilities.ToastMessage(this, Utilities.ToastMessageType.INFO, title);
                    var videoUrl = mItems[e.Position].FilePath;

                    var itemActivity = new Intent(this, typeof(ItemActivity));
                    itemActivity.PutExtra("MyVideo", videoUrl);
                    StartActivity(itemActivity);
                };

            }
            else if (status == CatalogStatus.FAILED)
            {
                Utilities.ToastMessage(this, Utilities.ToastMessageType.INFO, response.text);
            }
            else
            {
                Utilities.ToastMessage(this, Utilities.ToastMessageType.ERROR, "Connection failed, Please check your network connection");
            }
        }

        private CatalogStatus getVideos(string category, string subCategory)
        {
            CatalogStatus status;
            var authkey = AppConfig.Auth_Token;
            categoryId = GetCategoryIndex(category);
            ImageView imgViewLogo = FindViewById<ImageView>(Resource.Id.imgViewLogo);

            if (categoryId == 1)
            {
                imgViewLogo.SetBackgroundColor(Android.Graphics.Color.Rgb(255, 0, 0));
            }
            else if (categoryId == 2)
            {
                imgViewLogo.SetBackgroundColor(Android.Graphics.Color.Rgb(0, 128, 255));
            }
            else
            {
                imgViewLogo.SetBackgroundColor(Android.Graphics.Color.Rgb(174, 180, 4));
            }

            subcategoryId = 0;
            string jsonInput = "{\"categoryid\":\"" + categoryId + "\",\"subcategoryid\":\"" + subcategoryId + "\",\"authtoken\":\"" + AppConfig.Auth_Token + "\"}";
            var catalogJson = ServerCommunication.ServerCallWebRequest(AppConfig.URL_GET_VIDEOS, jsonInput);
            catalogResponse = JsonConvert.DeserializeObject<CatalogResponse>(catalogJson);
            response = catalogResponse.Response;

            if (catalogResponse.Response.status == "success")
            {
                status = CatalogStatus.SUCCESS;
            }
            else
            {
                status = CatalogStatus.FAILED;
            }

            return status;

        }

        private int GetCategoryIndex(string category)
        {
            switch (category)
            {
                case "Activity":
                    categoryId = 1;
                    break;
                case "Train":
                    categoryId = 2;
                    break;
                case "Recover":
                    categoryId = 3;
                    break;
                default:
                    categoryId = 1;
                    break;
            }
            return categoryId;
        }
        private string GetPathToImage(Uri uri)
        {
            string path = null;
            // The projection contains the columns we want to return in our query.
            string[] projection = new[] { Android.Provider.MediaStore.Images.Media.InterfaceConsts.Data };
            using (ICursor cursor = ManagedQuery(uri, projection, null, null, null))
            {
                if (cursor != null)
                {
                    int columnIndex = cursor.GetColumnIndexOrThrow(Android.Provider.MediaStore.Images.Media.InterfaceConsts.Data);
                    cursor.MoveToFirst();
                    path = cursor.GetString(columnIndex);
                }
            }
            return path;
        }



    }
    public enum CatalogStatus
    {
        SUCCESS,
        FAILED

    }
}