
using System;
using CoreGraphics;
using UIKit;

namespace XamBodyFitIOS
{
    public partial class CustomViewController : UIViewController
    {
        UITextField usernameField, passwordField;

        public CustomViewController()
            : base("CustomViewController", null)
        {
            UIImage logo = UIImage.FromBundle("Images/InitialScreen/logo-small.png");
            UIImageView imageView = new UIImageView(new System.Drawing.Rectangle(0, 0, 140, 44));
            imageView.Image = logo;
            NavigationItem.TitleView = imageView;
        }

        public CustomViewController(IntPtr handle)
            : base(handle)
        {
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
                Frame = new CGRect(10, 32, w - 20, h)
            };
            usernameField.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            // keep the code the username UITextField
            passwordField = new UITextField
            {
                Placeholder = "Enter your password",
                BorderStyle = UITextBorderStyle.RoundedRect,
                Frame = new CGRect(10, 64, w - 20, h),
                SecureTextEntry = true,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth
            };


            var submitButton = UIButton.FromType(UIButtonType.RoundedRect);

            submitButton.Frame = new CGRect(10, 120, w - 20, 44);
            submitButton.SetTitle("Submit", UIControlState.Normal);
            submitButton.BackgroundColor = UIColor.White;
            submitButton.Layer.CornerRadius = 5f;
            submitButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

            submitButton.TouchUpInside += delegate
            {
                Console.WriteLine("Submit button pressed");
            };
            View.AddSubviews(new UIView[] { usernameField, passwordField, submitButton });

        }
    }
}