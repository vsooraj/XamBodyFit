using System;
using CoreGraphics;
using UIKit;

namespace XamBodyFitIOS
{
    public partial class MainViewController : UIViewController
    {
        public MainViewController()
            : base("MainViewController", null)
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

            var facebookButton = UIButton.FromType(UIButtonType.RoundedRect);
            facebookButton.Frame = new CGRect(10, 230, w - 20, 44);
            facebookButton.SetTitle("Sign Up with Facebook", UIControlState.Normal);
            facebookButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            facebookButton.BackgroundColor = UIColor.FromRGB(59, 89, 152);
            //facebookButton.Layer.CornerRadius = 5f;
            facebookButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

            facebookButton.TouchUpInside += delegate
            {
                var vc = new FaceBookViewController();
                this.NavigationController.PushViewController(vc, true);
                Console.WriteLine("Facebook button pressed");
            };

            var emailButton = UIButton.FromType(UIButtonType.RoundedRect);
            emailButton.Frame = new CGRect(10, 280, w - 20, 44);
            emailButton.SetTitle("Sign Up with Email", UIControlState.Normal);
            emailButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            emailButton.BackgroundColor = UIColor.FromRGB(213, 15, 37);
            emailButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

            emailButton.TouchUpInside += delegate
            {
                var vc = new EmailViewController();
                this.NavigationController.PushViewController(vc, true);
                Console.WriteLine("Email button pressed");
            };

            var alreadyButton = UIButton.FromType(UIButtonType.RoundedRect);
            alreadyButton.Frame = new CGRect(10, 330, w - 20, 44);
            alreadyButton.SetTitle("Already on BODYFIT", UIControlState.Normal);
            alreadyButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            alreadyButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

            alreadyButton.TouchUpInside += delegate
            {
                var vc = new AlreadyViewController();
                this.NavigationController.PushViewController(vc, true);
                Console.WriteLine("Already button pressed");
            };

            View.AddSubviews(new UIView[] { facebookButton, emailButton, alreadyButton });
        }
    }
}