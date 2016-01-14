using System;
using CoreGraphics;
using UIKit;

namespace XamBodyFitIOS
{
    public partial class AlreadyViewController : UIViewController
    {
        UITextField usernameField, passwordField;
        public AlreadyViewController()
            : base("AlreadyViewController", null)
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

            usernameField = new UITextField
            {
                Placeholder = "Enter your username",
                BorderStyle = UITextBorderStyle.RoundedRect,
                Frame = new CGRect(10, 230, w - 20, h),

            };
            usernameField.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            // keep the code the username UITextField
            passwordField = new UITextField
            {
                Placeholder = "Enter your password",
                BorderStyle = UITextBorderStyle.RoundedRect,
                Frame = new CGRect(10, 270, w - 20, h),
                SecureTextEntry = true,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth
            };


            var submitButton = UIButton.FromType(UIButtonType.RoundedRect);

            submitButton.Frame = new CGRect(10, 330, w - 20, 44);
            submitButton.SetTitle("Login", UIControlState.Normal);
            submitButton.BackgroundColor = UIColor.White;
            submitButton.Layer.CornerRadius = 1f;
            submitButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

            submitButton.TouchUpInside += delegate
            {
                Console.WriteLine("Login button pressed");

                var vc = new MenuViewController();
                this.NavigationController.PushViewController(vc, true);
                //if (IsEMailValid() && IsPasswordValid())
                //{
                //    var vc = new MenuViewController();
                //    this.NavigationController.PushViewController(vc, true);
                //}
                //else
                //{
                //    Alert("Login Error", "Bad username or password");
                //}
            };
            View.AddSubviews(new UIView[] { usernameField, passwordField, submitButton });
        }
        private bool IsEMailValid()
        {
            return !String.IsNullOrEmpty(usernameField.Text.Trim());
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