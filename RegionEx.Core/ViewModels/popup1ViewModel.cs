using Cirrious.MvvmCross.ViewModels;

namespace RegionEx.Core.ViewModels
{
    public class popup1ViewModel
        : MvxViewModel
    {
        // Allow access to navigation commands
        private FirstViewModel _parent;
        public FirstViewModel Parent { get { return _parent; } }

        public popup1ViewModel(FirstViewModel parent) 
        {
            _parent = parent;
        }




        /////////////////////////////////////////////////////
        /// Used to demonstrate bindings work in the layout
        /////////////////////////////////////////////////////


        private string _title = "First Popup Screen";
        public string Title
        {
            get { return _title; }
            set 
            { 
                _title = value; 
                RaisePropertyChanged(() => Title);
                RaisePropertyChanged(() => Length);
            }
        }

        public int Length
        {
            get { return _title.Length; }
        }
    }
}
