
using System;
using System.Drawing;
using CoreGraphics;
using Foundation;
using UIKit;

namespace XamBodyFitIOS
{
    public partial class EmailViewController : UIViewController
    {
        UITextField firstNameField, lastNameField, emailFiled, passwordField;

        UIView paddingView = new UIView(new RectangleF(0, 0, 26, 16)) { BackgroundColor = UIColor.Clear };

        UIView paddingView1 = new UIView(new RectangleF(0, 0, 26, 16)) { BackgroundColor = UIColor.Clear };

        UIView paddingView2 = new UIView(new RectangleF(0, 0, 26, 16)) { BackgroundColor = UIColor.Clear };

        UIView paddingView3 = new UIView(new RectangleF(0, 0, 26, 16)) { BackgroundColor = UIColor.Clear };

        public EmailViewController()
            : base("EmailViewController", null)
        {
            UIImage logo = UIImage.FromBundle("Images/InitialScreen/logo-small.png");
            UIImageView imageView = new UIImageView(new System.Drawing.Rectangle(0, 0, 140, 44));
            imageView.Image = logo;
            NavigationItem.TitleView = imageView;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }
        public override void ViewWillAppear(bool animated)
        {
            this.InvokeOnMainThread(delegate
            {
                this.NavigationController.NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
                this.NavigationController.View.BackgroundColor = UIColor.Clear;
                this.NavigationController.NavigationBar.BackgroundColor = UIColor.Clear;
                this.NavigationController.NavigationBar.ShadowImage = new UIImage();
                this.NavigationController.NavigationBar.BarTintColor = UIColor.White;
                NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
            });

            base.ViewWillAppear(animated);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.View.InsertSubview(new UIImageView(UIImage.FromBundle("Images/InitialScreen/@3_bg.png")), 0);
            nfloat h = 31.0f;
            nfloat w = View.Bounds.Width;

            var leftViewFirstName = new UIImageView
            {
                Frame = new CGRect(0, 0, 16, 16),
                BackgroundColor = UIColor.Clear,
                Image = UIImage.FromBundle("Images/Sign Up/user.png")
            };
            paddingView.AddSubview(leftViewFirstName);

            firstNameField = new UITextField
            {
                AttributedPlaceholder = new NSAttributedString("First Name", null, UIColor.Gray),
                BorderStyle = UITextBorderStyle.None,
                Frame = new CGRect(10, 200, w - 20, h),
                BackgroundColor = UIColor.Clear,
                TextColor = UIColor.White,

            };
            firstNameField.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            // firstNameField.Layer.BorderWidth = 1f;
            firstNameField.LeftView = paddingView;
            this.firstNameField.LeftViewMode = UITextFieldViewMode.Always;



            var leftViewLastName = new UIImageView
            {
                Frame = new CGRect(0, 0, 16, 16),
                BackgroundColor = UIColor.Clear,
                Image = UIImage.FromBundle("Images/Sign Up/user.png")
            };
            paddingView1.AddSubview(leftViewLastName);

            lastNameField = new UITextField
            {
                AttributedPlaceholder = new NSAttributedString("Last Name", null, UIColor.Gray),
                BorderStyle = UITextBorderStyle.None,
                Frame = new CGRect(10, 240, w - 20, h),
                BackgroundColor = UIColor.Clear,
                TextColor = UIColor.White
            };
            lastNameField.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            lastNameField.LeftView = paddingView1;
            this.lastNameField.LeftViewMode = UITextFieldViewMode.Always;

            var leftViewEmail = new UIImageView
            {
                Frame = new CGRect(0, 0, 16, 16),
                BackgroundColor = UIColor.Clear,
                Image = UIImage.FromBundle("Images/Sign Up/email.png")
            };
            paddingView2.AddSubview(leftViewEmail);
            emailFiled = new UITextField
            {
                AttributedPlaceholder = new NSAttributedString("Email ", null, UIColor.Gray),
                BorderStyle = UITextBorderStyle.None,
                Frame = new CGRect(10, 280, w - 20, h),
                BackgroundColor = UIColor.Clear,
                TextColor = UIColor.White
            };
            emailFiled.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            emailFiled.LeftView = paddingView2;
            this.emailFiled.LeftViewMode = UITextFieldViewMode.Always;

            var leftViewPassword = new UIImageView
            {
                Frame = new CGRect(0, 0, 16, 16),
                BackgroundColor = UIColor.Clear,
                Image = UIImage.FromBundle("Images/Sign Up/password.png")
            };
            paddingView3.AddSubview(leftViewPassword);
            passwordField = new UITextField
            {
                AttributedPlaceholder = new NSAttributedString("Password", null, UIColor.Gray),
                BorderStyle = UITextBorderStyle.None,
                Frame = new CGRect(10, 320, w - 20, h),
                BackgroundColor = UIColor.Clear,
                TextColor = UIColor.White,
                SecureTextEntry = true,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth
            };

            passwordField.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            passwordField.LeftView = paddingView3;
            this.passwordField.LeftViewMode = UITextFieldViewMode.Always;

            var signUpButton = UIButton.FromType(UIButtonType.RoundedRect);
            signUpButton.Frame = new CGRect(10, 374, w - 20, 44);
            signUpButton.SetTitle("Sign Up", UIControlState.Normal);
            signUpButton.BackgroundColor = UIColor.Green;
            signUpButton.Layer.CornerRadius = 1f;
            signUpButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

            signUpButton.TouchUpInside += delegate
            {
                Console.WriteLine("Sign Up button pressed");
                //Validate our Username & Password.
                //This is usually a web service call.
                if (IsFirstNameValid() && IsLastNameValid() && IsEMailValid() && IsPasswordValid())
                {
                    ////We have successfully authenticated a the user,
                    ////Now fire our OnLoginSuccess Event.
                    //if (OnLoginSuccess != null)
                    //{
                    //    OnLoginSuccess(sender, new EventArgs());
                    //}
                }
                else
                {
                    new UIAlertView("Sign Up Error", "Bad First/Last name/Email or password", null, "OK", null).Show();
                }
            };

            View.AddSubviews(new UIView[] { firstNameField, lastNameField, emailFiled, passwordField, signUpButton });
            //firstNameField.BecomeFirstResponder();
        }

        private bool IsFirstNameValid()
        {
            return !String.IsNullOrEmpty(firstNameField.Text.Trim());
        }

        private bool IsLastNameValid()
        {
            return !String.IsNullOrEmpty(lastNameField.Text.Trim());
        }
        private bool IsEMailValid()
        {
            return !String.IsNullOrEmpty(emailFiled.Text.Trim());
        }
        private bool IsPasswordValid()
        {
            return !String.IsNullOrEmpty(passwordField.Text.Trim());
        }
        public static void Alert(string title, string message)
        {
            UIAlertView alert = new UIAlertView();
            alert.Title = title;
            alert.Message = message;
            alert.AddButton("OK");
            alert.Show();
        }
    }
}