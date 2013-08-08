using Android.App;
using Android.Content.PM;
using Cirrious.MvvmCross.Droid.Views;

namespace RegionEx.Droid
{
    [Activity(
		Label = "Region Layout Example"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Landscape)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}