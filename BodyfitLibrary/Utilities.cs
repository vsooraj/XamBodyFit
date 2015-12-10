using Android.App;
using Android.Widget;


namespace BodyfitLibrary
{
    public class Utilities
    {
        public static void ToastMessage(Activity activity, ToastMessageType meassageType, string message)
        {
            Toast.MakeText(activity, meassageType.ToString() + ":" + message, ToastLength.Long).Show();
        }
        public enum ToastMessageType
        {
            ERROR,
            EXCEPTION,
            INFO
        }
    }
}
