
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
        private Button btnLogin;
        EditText txtEmail, txtPassword;
        RegexUtilities regexUtilities = new RegexUtilities();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += new EventHandler(btnLogin_Click);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);

        }
        void btnLogin_Click(object sender, EventArgs e)
        {

            var authkey = AppConfig.Auth_Token;
            var status = Login(authkey, txtEmail.Text, txtPassword.Text);
            if (status == LoginStatus.SUCCESS.ToString())
            {
                StartActivity(typeof(LoginActivity));
            }
            else
            {
                ToastMessage(status);
            }

        }


        private bool validatePassword(string password)
        {
            bool valid = false;
            if (string.IsNullOrWhiteSpace(password))
                return (password.Length > 5 ? true : false);
            return valid;
        }

        private string Login(string authKey, string email, string password)
        {
            //if (regexUtilities.IsValidEmail(email) && validatePassword(password))
            //{
            AppConfig.Auth_Token = "5c3830f453a9219f22c8e5cca41f511d";
            string jsonInput = "{\"emailid\":\"" + email + "\"authtoken\":\"" + AppConfig.Auth_Token + "\"password\":\"" + password + "\"}";
            //var jsonInput = "";// " "{'password' : '1234',""authtoken"": ""5c3830f453a9219f22c8e5cca41f511d"",""emailid"" : ""test@1234.com""}"";
            var loginJson = ServerCommunication.LoginServerCommunication(AppConfig.URL_LOGIN, jsonInput);
            LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(loginJson);

            //}
            //else
            //{
            //    ToastMessage("Either email or password not valid, please enter valid one.");
            //}
            return LoginStatus.SUCCESS.ToString();

        }

        private void ToastMessage(string message)
        {
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }
        private void JsonKeyValue(string tempJson)
        {
            //JObject parsed = JObject.Parse(tempJson);

            //foreach (var pair in parsed)
            //{
            //    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            //}
        }





    }
    public enum LoginStatus
    {
        SUCCESS,
        FAILED
    }





}