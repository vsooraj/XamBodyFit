
using System;
using CoreGraphics;
using UIKit;

namespace XamBodyFitIOS
{
    public partial class MenuViewController : UITabBarController
    {
        UIViewController tab1, tab2;
        nfloat navHeight = 60;
        private UIView TopView { get; set; }
        private UIView BottomView { get; set; }

        public MenuViewController()
            : base("MenuViewController", null)
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
                this.NavigationController.NavigationBar.BackgroundColor = UIColor.FromRGB(250, 20, 11);
                this.NavigationController.NavigationBar.ShadowImage = new UIImage();
                this.NavigationController.NavigationBar.BarTintColor = UIColor.White;
                NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
                navHeight = this.NavigationController.NavigationBar.Bounds.Height;

            });

            base.ViewWillAppear(animated);
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TopView = new UIView(new CGRect(0, navHeight + 5, View.Bounds.Width, View.Bounds.Height - 50)) { BackgroundColor = UIColor.Blue };
            BottomView = new UIView(new CGRect(0, TopView.Bounds.Height + 5, View.Bounds.Width, 50)) { BackgroundColor = UIColor.Yellow };

            //this.View.InsertSubview(new UIImageView(UIImage.FromBundle("Images/InitialScreen/@3_bg.png")), 0);
            // Perform any additional setup after loading the view, typically from a nib.
            nfloat h = 31.0f;
            nfloat w = View.Bounds.Width;
            h = TopView.Bounds.Height - navHeight;
            h = h / 3;

            var activateButton = UIButton.FromType(UIButtonType.RoundedRect);
            activateButton.Frame = new CGRect(0, navHeight + 5, w, h);
            activateButton.SetTitle("ACTIVATE", UIControlState.Normal);
            activateButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            activateButton.BackgroundColor = UIColor.FromRGB(250, 20, 11);
            //activateButton.Layer.CornerRadius = 5f;
            activateButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            // activateButton.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

            var trainButton = UIButton.FromType(UIButtonType.RoundedRect);
            trainButton.Frame = new CGRect(0, activateButton.Bounds.Height + 5, w, h);
            trainButton.SetTitle("TRIAL", UIControlState.Normal);
            trainButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            trainButton.BackgroundColor = UIColor.FromRGB(86, 163, 252);
            //trainButton.Layer.CornerRadius = 5f;
            trainButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            //trainButton.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

            var recoverButton = UIButton.FromType(UIButtonType.RoundedRect);
            //recoverButton.Frame = new CGRect(0, h + h, w, h);
            recoverButton.SetTitle("RECOVER", UIControlState.Normal);
            recoverButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            recoverButton.BackgroundColor = UIColor.FromRGB(174, 180, 4);
            //recoverButton.Layer.CornerRadius = 5f;
            recoverButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            //recoverButton.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

            var likeButton = UIButton.FromType(UIButtonType.RoundedRect);
            likeButton.Frame = new CGRect(10, 425, w - 100, 40);
            likeButton.SetTitle("LIKE", UIControlState.Normal);
            likeButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            likeButton.BackgroundColor = UIColor.FromRGB(59, 89, 152);
            //likeButton.Layer.CornerRadius = 5f;
            likeButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            //likeButton.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;


            var watchButton = UIButton.FromType(UIButtonType.RoundedRect);
            watchButton.Frame = new CGRect(40, 425, w - 100, 40);
            watchButton.SetTitle("WATCH", UIControlState.Normal);
            watchButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            watchButton.BackgroundColor = UIColor.FromRGB(250, 20, 11);
            //watchButton.Layer.CornerRadius = 5f;
            watchButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            //watchButton.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
            //UIView paddingViewLike = new UIView(new CGRect(10, 425, w - 100, 40)) { BackgroundColor = UIColor.FromRGB(59, 89, 152) };
            tab1 = new UIViewController();
            // tab1.Add(paddingViewLike);
            //tab1.TabBarItem = new UITabBarItem("LIKE", UIImage.FromBundle("Images/Main/@3_LikeWatch.png"), 0);
            tab1.Title = "LIKE";
            //tab1.View.BackgroundColor = UIColor.FromRGB(59, 89, 152);
            //UIView paddingViewWatch = new UIView(new CGRect(40, 425, w - 100, 40)) { BackgroundColor = UIColor.FromRGB(250, 20, 11) };
            tab2 = new UIViewController();
            // tab2.Add(paddingViewWatch);
            // tab2.TabBarItem = new UITabBarItem("WATCH", UIImage.FromBundle("Images/Main/@3_LikeWatch.png"), 1);
            tab2.Title = "WATCH";
            //tab2.View.BackgroundColor = UIColor.FromRGB(174, 180, 4);

            var tabs = new UIViewController[] { tab1, tab2 };

            activateButton.TranslatesAutoresizingMaskIntoConstraints = false;
            View.TranslatesAutoresizingMaskIntoConstraints = false;
            trainButton.TranslatesAutoresizingMaskIntoConstraints = false;
            recoverButton.TranslatesAutoresizingMaskIntoConstraints = false;
            ViewControllers = tabs;

            TopView.AddSubview(activateButton);
            TopView.AddSubview(trainButton);
            BottomView.AddSubview(likeButton);
            BottomView.AddSubview(watchButton);
            View.AddSubviews(new UIView[] { TopView, BottomView });


        }
    }
}