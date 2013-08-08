using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;

namespace RegionEx.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {

        ///////////////////////////////////////
        /// View Models for each region
        ///////////////////////////////////////

        private MvxViewModel _nav = null;
        public MvxViewModel Nav
        {
            get { return _nav; }
            set { _nav = value; RaisePropertyChanged(() => Nav); }
        }

        private MvxViewModel _main = null;
        public MvxViewModel Main
        {
            get { return _main; }
            set { _main = value; RaisePropertyChanged(() => Main); }
        }

        private MvxViewModel _popup = null;
        public MvxViewModel Popup
        {
            get { return _popup; }
            set 
            { 
                _popup = value;
                // Close the popup if the viewmodel is removed
                ShowPopup = (_popup != null); 
                RaisePropertyChanged(() => Popup); 
            }
        }

        private bool _showPopup = false;
        public bool ShowPopup
        {
            get { return _showPopup; }
            set { _showPopup = value; RaisePropertyChanged(() => ShowPopup); }
        }




        ///////////////////////////////////////
        /// Commands for controling navigation
        ///////////////////////////////////////

        public ICommand FirstMain { get { return new MvxCommand(() => FirstMainCommand()); } }
        public ICommand SecondMain { get { return new MvxCommand(() => SecondMainCommand()); } }
        
        public ICommand FirstPopup { get { return new MvxCommand(() => FirstPopupCommand()); } }
        public ICommand SecondPopup { get { return new MvxCommand(() => SecondPopupCommand()); } }

        public ICommand ClosePopup { get { return new MvxCommand(() => ClosePopupCommand()); } }


        private void FirstMainCommand()
        {
            // No change needed if this is already displayed
            if (Main.GetType() == typeof(main1ViewModel))
                return;
            
            // Update the view model
            Main = new main1ViewModel(this);

            // Display the view model
            ShowViewModel<main1ViewModel>();
            
        }
        private void SecondMainCommand()
        {
            // No change needed if this is already displayed
            if (Main.GetType() == typeof(main2ViewModel))
                return;
            
            // Update the view model
            Main = new main2ViewModel(this);

            // Display the view model
            ShowViewModel<main2ViewModel>();
        
        }

        public void ClosePopupCommand()
        {
            // Remove the view model. ShowPopup will be set to false automatically.
            Popup = null;
        }

        private void FirstPopupCommand()
        {
            // Update the view model
            Popup = new popup1ViewModel(this);

            // Display the view model
            ShowViewModel<popup1ViewModel>();
        }

        private void SecondPopupCommand()
        {
            // Update the view model
            Popup = new popup2ViewModel(this);

            // Display the view model
            ShowViewModel<popup2ViewModel>();
        }




        ///////////////////////////////////////
        /// Initial setup called by MvvmCross
        ///////////////////////////////////////

        public void Init()
        {
            // Set the initial view model
            Nav = new nav1ViewModel(this);
            Main = new main1ViewModel(this);
        }
    }
}
