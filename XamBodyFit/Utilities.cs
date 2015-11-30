

using Android.App;
using Android.Widget;
namespace XamBodyFit
{

    public class Utilities
    {
        public string uri = "http://dev2.cabotprojects.com/bodyfitAWS/webservices?procedure=";

        public enum ToastMessageType
        {
            ERROR,
            EXCEPTION,
            INFO
        }
        public string GetUri(string procedure)
        {

            switch (procedure)
            {
                case "initializeApp":
                    return uri += "initializeApp";
                default:
                    return uri += "initializeApp";
            }
        }
        public static void ToastMessage(Activity a, ToastMessageType meassageType, string message)
        {
            Toast.MakeText(a, meassageType.ToString() + ":" + message, ToastLength.Long).Show();
        }
    }
}