
using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;

namespace XamBodyFit
{
    [Activity]
    public class RegisterActivity : Activity
    {
        private Button btnRegister;
        EditText txtPassword;
        EditText txtEmail;
        EditText txtFirstName;
        EditText txtLastName;

        Validation validation = new Validation();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.register);
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtFirstName = FindViewById<EditText>(Resource.Id.txtFirstName);
            txtLastName = FindViewById<EditText>(Resource.Id.txtLastName);
            btnRegister.Click += (object sender, EventArgs e) =>
            {

                try
                {
                    var status = Register(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPassword.Text);
                    if (status == RegisterStatus.SUCCESS)
                    {
                        StartActivity(typeof(LoginActivity));
                    }
                    else if (status == RegisterStatus.INVALID_CREDENTIAL)
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
            };

        }
        private RegisterStatus Register(string firstName, string lastName, string email, string password)
        {
            RegisterStatus status;
            if (validation.ValidateName(firstName) && validation.ValidateName(lastName) && validation.ValidateEmail(email) && validation.ValidatePassword(password))
            {
                //{"firstname" :"sooraj","lastname" : "vidyasagar","password": "1304","authtoken": "7c8c1533878ac624832c35555b5bffdd","emailid" : "sooraj.v@cabotsolutions.com"}
                string jsonInput = "{\"firstname\":\"" + firstName + "\",\"lastname\":\"" + lastName + "\",\"emailid\":\"" + email + "\",\"password\":\"" + password + "\",\"authtoken\":\"" + AppConfig.Auth_Token + "\"}";
                var registerJson = ServerCommunication.Register(AppConfig.URL_REGISTER, jsonInput);
                RegisterResponse loginResponse = JsonConvert.DeserializeObject<RegisterResponse>(registerJson);
                if (loginResponse.Response.status == "success")
                {
                    status = RegisterStatus.SUCCESS;
                }
                else
                {
                    status = RegisterStatus.FAILED;
                }
            }
            else
            {
                status = RegisterStatus.INVALID_CREDENTIAL;
            }
            return status;

        }

        enum RegisterStatus
        {
            SUCCESS,
            FAILED,
            INVALID_CREDENTIAL
        }
    }
}