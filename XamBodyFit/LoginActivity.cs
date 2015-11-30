
using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;


namespace XamBodyFit
{
    [Activity(Label = "Enter valid credentials")]
    public class LoginActivity : Activity
    {
        private Button btnLogin, btnForgotPassword;
        EditText txtEmail, txtPassword;
        Validation validation = new Validation();
        Response response = new Response();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += new EventHandler(btnLogin_Click);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            btnForgotPassword = FindViewById<Button>(Resource.Id.btnForgotPassword);
            btnForgotPassword.Click += btnForgotPassword_Click;

        }

        void btnForgotPassword_Click(object sender, EventArgs e)
        {
            try
            {
                var authkey = AppConfig.Auth_Token;
                Device device = new Device();
                var deviceid = device.GetDeviceId();
                LoginStatus status = ForgotPassword(authkey, txtEmail.Text, deviceid);
                if (status == LoginStatus.PASSWORD_SEND_SUCCESSFULL)
                {
                    StartActivity(typeof(LoginActivity));
                    Utilities.ToastMessage(this, Utilities.ToastMessageType.INFO, response.text);
                }
                else if (status == LoginStatus.INVALID_CREDENTIAL)
                {
                    Utilities.ToastMessage(this, Utilities.ToastMessageType.INFO, response.text);
                }
                else
                {
                    Utilities.ToastMessage(this, Utilities.ToastMessageType.ERROR, "Connection failed, Please check your network connection");
                }
            }
            catch (Exception ex)
            {

                Utilities.ToastMessage(this, Utilities.ToastMessageType.EXCEPTION, ex.ToString());
            }
        }

        private LoginStatus ForgotPassword(string authkey, string email, string deviceid)
        {
            LoginStatus status;
            if (validation.ValidateEmail(email))
            {
                string jsonInput = "{\"emailid\":\"" + email + "\",\"deviceid\":\"" + deviceid + "\",\"authtoken\":\"" + AppConfig.Auth_Token + "\"}";
                var loginJson = ServerCommunication.Login(AppConfig.URL_LOGIN, jsonInput);
                LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(loginJson);
                response = loginResponse.Response;
                if (loginResponse.Response.status == "success")
                {
                    status = LoginStatus.PASSWORD_SEND_SUCCESSFULL;
                }
                else
                {
                    status = LoginStatus.PASSWORD_SEND_FAILED;
                }
            }
            else
            {
                status = LoginStatus.INVALID_CREDENTIAL;
            }
            return status;
        }
        void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var authkey = AppConfig.Auth_Token;
                LoginStatus status = Login(authkey, txtEmail.Text, txtPassword.Text);
                if (status == LoginStatus.SUCCESS)
                {
                    StartActivity(typeof(MenuActivity));
                }
                else if (status == LoginStatus.INVALID_CREDENTIAL)
                {
                    Utilities.ToastMessage(this, Utilities.ToastMessageType.ERROR, "Either email or password not valid, please enter a valid one.");
                }
                else
                {
                    Utilities.ToastMessage(this, Utilities.ToastMessageType.ERROR, "Connection failed, Please check your network connection");
                }
            }
            catch (Exception ex)
            {

                Utilities.ToastMessage(this, Utilities.ToastMessageType.EXCEPTION, ex.ToString());
            }

        }

        private LoginStatus Login(string authKey, string email, string password)
        {
            LoginStatus status;
            if (validation.ValidateEmail(email) && validation.ValidatePassword(password))
            {
                string jsonInput = "{\"emailid\":\"" + email + "\",\"password\":\"" + password + "\",\"authtoken\":\"" + AppConfig.Auth_Token + "\"}";
                var loginJson = ServerCommunication.Login(AppConfig.URL_LOGIN, jsonInput);
                LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(loginJson);
                if (loginResponse.Response.status == "success")
                {
                    status = LoginStatus.SUCCESS;
                }
                else
                {
                    status = LoginStatus.FAILED;
                }
            }
            else
            {
                status = LoginStatus.INVALID_CREDENTIAL;
            }
            return status;

        }









    }
    public enum LoginStatus
    {
        SUCCESS,
        FAILED,
        INVALID_CREDENTIAL,
        INFO,
        PASSWORD_SEND_SUCCESSFULL,
        PASSWORD_SEND_FAILED
    }





}