
using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace XamBodyFit
{
    [Activity(Label = "Enter valid credentials")]
    public class LoginActivity : Activity
    {
        private Button btnLogin;
        RegexUtilities regexUtilities = new RegexUtilities();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += new EventHandler(btnLogin_Click);

        }
        void btnLogin_Click(object sender, EventArgs e)
        {
            EditText txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            EditText txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            if (regexUtilities.IsValidEmail(txtEmail.Text) && validatePassword(txtPassword.Text))
            {
                StartActivity(typeof(CatalogActivity));
            }
            else
            {
                Toast.MakeText(this, "Either Email or Password not valid, Please enter valid one.", ToastLength.Long).Show();
            }
        }

        private bool validatePassword(string password)
        {
            bool valid = false;
            if (string.IsNullOrWhiteSpace(password))
                return (password.Length > 5 ? true : false);
            return valid;
        }


    }
}