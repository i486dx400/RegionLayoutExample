using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.ViewModels;
using Android.Support.V4.App;
using RegionEx.Core.ViewModels;
using System;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.CrossCore;
using Android.Widget;

namespace RegionEx.Droid.Views
{
    [Activity(Label = "FirstView with regions")]
    public class FirstView : MvxFragmentActivity, IFragmentHost
    {
        // Timeout for back button exit
        private const int lengthToWait = 3;
        // Initialize to something that won't exit on the first back button press
        private DateTime LastBackbuttonPress = DateTime.Now.AddSeconds(lengthToWait*-1);


        // Custom back button event handling
        public override void OnBackPressed()
        {
            DateTime now = DateTime.Now;
            TimeSpan offset = new TimeSpan(0, 0, lengthToWait);

            // Close the popup if it is open
            if (((FirstViewModel)ViewModel).ShowPopup)
            {
                ((FirstViewModel)ViewModel).ClosePopupCommand();
            }
            // Stop app from immediately exiting unless the back button is 
            //    pressed twice within "lengthToWait" seconds
            else if ((now - LastBackbuttonPress).TotalSeconds > offset.TotalSeconds)
            {
                // Back button was just pressed
                LastBackbuttonPress = now;
                Toast.MakeText(this, "Press the back button again to exit.", ToastLength.Long).Show();
            }
            else
            {
                // Normal back button behavior
                base.OnBackPressed();
            }
        }

        protected override void OnViewModelSet()
        {
            // Set the layout
            SetContentView(Resource.Layout.FirstView);
            

            // Register fragments
            var regionPresenter = Mvx.Resolve<ICustomPresenter>();
            regionPresenter.Register(typeof(nav1ViewModel), this);
            regionPresenter.Register(typeof(main1ViewModel), this);
            regionPresenter.Register(typeof(main2ViewModel), this);
            regionPresenter.Register(typeof(popup1ViewModel), this);
            regionPresenter.Register(typeof(popup2ViewModel), this);


            // Display initial fragments
            replaceFragment(
                GetView(((FirstViewModel)ViewModel).Nav.GetType()), 
                Resource.Id.NavigationRegion, 
                ((FirstViewModel)ViewModel).Nav);
            replaceFragment(
                GetView(((FirstViewModel)ViewModel).Main.GetType()), 
                Resource.Id.MainRegion, 
                ((FirstViewModel)ViewModel).Main);
        }


        // Called from the custom presenter when the presenter
        //   attempts to display a fragment that was registered
        //   from the OnViewModelSet() function above.
        public bool Show(MvxViewModelRequest request)
        {
            int resourceID;
            MvxViewModel vm = null;
            
            // Figure out which fragment is being replaced
            if (TypeOfNavigation(request)) {
                resourceID = Resource.Id.NavigationRegion;
                vm = ((FirstViewModel)ViewModel).Nav;

            } else if (TypeOfMain(request)) {
                resourceID = Resource.Id.MainRegion;
                vm = ((FirstViewModel)ViewModel).Main;

            } else if (TypeOfPopup(request)) {
                resourceID = Resource.Id.PopupRegion;
                vm = ((FirstViewModel)ViewModel).Popup;

            } else {
                // Exit here.  Not in any of these regions.
                return false;
            }

            // Display the new fragment on the screen
            replaceFragment(GetView(request.ViewModelType), resourceID, vm);

            return true;
        }

        private void replaceFragment(MvxFragment fragmentView, int resourceID, IMvxViewModel viewModel, bool backStack=false)
        {
            // Set the view model
            fragmentView.ViewModel = viewModel;

            // load fragment into view
            var ft = SupportFragmentManager.BeginTransaction();
            ft.Replace(resourceID, fragmentView);
            if (backStack)
            {
                // The back button will return to this.  However,
                //   setting this may mess up the custom
                //   OnBackPressed() behavior
                ft.AddToBackStack(null);
            }
            ft.Commit();
        }

        private bool TypeOfNavigation(MvxViewModelRequest request)
        {
            return (request.ViewModelType == typeof(nav1ViewModel));
                
        }

        private bool TypeOfMain(MvxViewModelRequest request)
        {
            return (request.ViewModelType == typeof(main1ViewModel))
                || (request.ViewModelType == typeof(main2ViewModel));
        }

        private bool TypeOfPopup(MvxViewModelRequest request)
        {
            return (request.ViewModelType == typeof(popup1ViewModel))
                || (request.ViewModelType == typeof(popup2ViewModel));
        }


        private MvxFragment GetView(Type ViewModelType)
        {
            // Link the view model to the view
            if (ViewModelType == typeof(nav1ViewModel))
            {
                return new nav1View();
            }
            else if (ViewModelType == typeof(main1ViewModel))
            {
                return new main1View();
            }
            else if (ViewModelType == typeof(main2ViewModel))
            {
                return new main2View();
            }
            else if (ViewModelType == typeof(popup1ViewModel))
            {
                return new popup1View();
            }
            else if (ViewModelType == typeof(popup2ViewModel))
            {
                return new popup2View();
            }
            
            return null;
        }
    }
}