
using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace XamBodyFit
{
    [Activity(Label = "Please provide your details")]
    public class RegisterActivity : Activity
    {
        private Button btnRegister;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.register);
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += new EventHandler(btnRegister_Click);

        }
        void btnRegister_Click(object sender, EventArgs e)
        {
            EditText txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            EditText txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
           
        }
    }
}