using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Fragging;

namespace RegionEx.Droid.Views
{
    [Activity(
        Label = "LoadingScreenView"
        , NoHistory = true)]
    public class LoadingScreenView : MvxFragmentActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.loadingScreen);
        }
    }
}