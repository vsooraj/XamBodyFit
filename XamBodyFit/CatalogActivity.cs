
using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace XamBodyFit
{
    [Activity(Theme = "@style/CustomActionBarTheme")]
    public class CatalogActivity : Activity
    {
        ListView mListView;
        int categoryId, subCategoryId;
        Response response = new Response();
        List<Video> mItems;
        CatalogResponse catalogResponse;

        #region DrawableLayout variables
        List<string> leftItems = new List<string>();
        ArrayAdapter leftAdapater;
        ListView leftListView;
        DrawerLayout drawerLayout;
        ActionBarDrawerToggle drawerToggle;
        Dictionary<string, string> _navigation = new Dictionary<string, string>();

        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.catalog);
            mListView = FindViewById<ListView>(Resource.Id.myListView);

            categoryId = int.Parse(Intent.GetStringExtra("CategoryId") ?? "0");

            Button btnActivate = FindViewById<Button>(Resource.Id.btnActivate);
            Button btnTrain = FindViewById<Button>(Resource.Id.btnTrain);
            Button btnRecover = FindViewById<Button>(Resource.Id.btnRecover);
            #region DrawableLayout
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.myDrawer);
            leftListView = FindViewById<ListView>(Resource.Id.leftListView);
            leftItems = MenuRepository.GetMenuItems();
            _navigation = MenuRepository.GetMenuItemsWithUri();
            drawerToggle = new MyActionBarDrawerToggle(this, drawerLayout, Resource.Drawable.menu, Resource.String.open_drawer, Resource.String.close_drawer);

            leftAdapater = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, leftItems);
            leftListView.Adapter = leftAdapater;
            leftListView.ItemClick += (sender, args) => leftListItemClicked(args.Position);
            drawerLayout.SetDrawerListener(drawerToggle);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayShowTitleEnabled(true);
            #endregion

            btnActivate.Click += (object sender, EventArgs args) =>
            {
                GetList(1, subCategoryId);
            };
            btnTrain.Click += (object sender, EventArgs e) =>
            {
                GetList(2, subCategoryId);
            };
            SetTab(categoryId);
        }
        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            drawerToggle.SyncState();
        }
        public override bool OnOptionsItemSelected(IMenuItem items)
        {
            if (drawerToggle.OnOptionsItemSelected(items))
            {
                return true;
            }
            return base.OnOptionsItemSelected(items);
        }

        private void leftListItemClicked(int p)
        {
            var tempItem = leftItems[p];
            //Toast.MakeText(this, tempItem, ToastLength.Short).Show();
            string url;
            if (tempItem != "Exit")
            {
                if (_navigation.TryGetValue(tempItem, out url))
                {
                    var uri = Android.Net.Uri.Parse(url);
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }
            }
            else
            {
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            }
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            GetList(3, subCategoryId);
        }
        private void GetList(int categoryId, int subCategoryId)
        {
            CatalogStatus status = getVideos(categoryId, subCategoryId);
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
                    itemActivity.PutExtra("CategoryId", categoryId);
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



        private CatalogStatus getVideos(int categoryId, int subcategoryId)
        {
            CatalogStatus status;
            var authkey = AppConfig.Auth_Token;
            //ImageView imgViewLogo = FindViewById<ImageView>(Resource.Id.imgViewLogo);

            //if (categoryId == 1)
            //{
            //    imgViewLogo.SetBackgroundColor(Android.Graphics.Color.Rgb(255, 0, 0));
            //}
            //else if (categoryId == 2)
            //{
            //    imgViewLogo.SetBackgroundColor(Android.Graphics.Color.Rgb(0, 128, 255));
            //}
            //else
            //{
            //    imgViewLogo.SetBackgroundColor(Android.Graphics.Color.Rgb(174, 180, 4));
            //}

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

        private void SetTab(int categoryId)
        {
            GetList(categoryId, subCategoryId);
            //ImageView imgViewLogo = FindViewById<ImageView>(Resource.Id.imgViewLogo);
            //Button btnActivate = FindViewById<Button>(Resource.Id.btnActivate);
            //Button btnTrain = FindViewById<Button>(Resource.Id.btnTrain);
            //Button btnRecover = FindViewById<Button>(Resource.Id.btnRecover);
            //if (categoryId == 1)
            //{
            //    Toast.MakeText(this, "ACTIVATE", ToastLength.Short).Show();
            //    imgViewLogo.SetBackgroundColor(Android.Graphics.Color.Rgb(255, 0, 0));
            //}
            //else if (categoryId == 2)
            //{
            //    Toast.MakeText(this, "TRAIN", ToastLength.Short).Show();
            //    imgViewLogo.SetBackgroundColor(Android.Graphics.Color.Rgb(0, 128, 255));
            //}
            //else
            //{
            //    Toast.MakeText(this, "RECOVER", ToastLength.Short).Show();
            //    imgViewLogo.SetBackgroundColor(Android.Graphics.Color.Rgb(174, 180, 4));
            //}
        }
    }
    public enum CatalogStatus
    {
        SUCCESS,
        FAILED

    }
}