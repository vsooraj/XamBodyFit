using System;


namespace XamBodyFit
{

    public class AppConfig
    {
        public static string uri = "http://dev2.cabotprojects.com/bodyfit-cms/webservices?procedure=";

        public static string Auth_Token;

        public AppConfig(string auth_Token)
        {
            Auth_Token = auth_Token;
        }

        /// <summary>
        /// Server user Initialize url with Device Id
        /// This API is used to initialize the bodyFit-app application. 
        /// By using this API app will get an authentication token. 
        /// So on every request  app will send this authentication token to server for validation.
        /// </summary>
        public static String URL_INITIALIZE = uri + "initializeApp";

        /// <summary>
        ///This API is used to login into the BodyFit app.
        ///By using this API will get the userid and new auth token for the application.
        ///In the REQUEST side below keys are required.  "authtoken",   "deviceid",  "email", "password"
        /// </summary>
        public static String URL_LOGIN = uri + "loginApp";

        /// <summary>
        /// This API is used to login into the eventu app.
        /// By using this API will new auth token for the application.
        /// In the REQUEST side below keys are required.  "authtoken",
        /// "deviceid",  "email", "password","firstname","lastname"
        /// </summary>
        public static String URL_REGISTER = uri + "userSignup";

        /// <summary>
        /// This API is used to login into the BodyFit app using facebook,twitter,youtube. 
        /// By using this API will new auth token for the application.
        /// In the REQUEST side below keys are required.
        /// "authtoken", "deviceid","type","socialmediaid","firstname","lastname"
        /// </summary>
        public static String URL_SOCIAL_MEDIA_LOGIN = uri + "twitterFbLoginSignUp";

        /// <summary>
        /// This API is used to do forgot password. 
        /// By using this API we will send a reset password link to the corresponding email address and return  a authtoken and status.
        /// All REQUEST parameters are mandatory.
        /// </summary>
        public static String URL_FORGOT_PASSWORD = uri + "forgotPassword";

        /// <summary>
        /// This API is used to get all subcategory under the category. All REQUEST parameters are mandatory.
        /// </summary>
        public static String URL_GRT_SUB_CATEGORY = uri + "getSubcategory";

        /// <summary>
        /// This API is used to get all videos under the category or subcategory. All REQUEST parameters are mandatory.
        /// </summary>
        public static String URL_GET_VIDEOS = uri + "getVideos";

        /// <summary>
        /// This API is used to update user watching videos
        /// </summary>
        public static String URL_USER_WATCHING_VIDEO = uri + "UserWatchingVideo";

        /// <summary>
        /// This API is used to check and invite Fb friends
        /// </summary>
        public static String URL_INVITE_FRIENDS = uri + "FbinviteFriends";

    }
}