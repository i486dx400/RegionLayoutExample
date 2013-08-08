using Cirrious.MvvmCross.ViewModels;

namespace RegionEx.Core.ViewModels
{
    public class popup2ViewModel
        : MvxViewModel
    {
        // Allow access to navigation commands
        private FirstViewModel _parent;
        public FirstViewModel Parent { get { return _parent; } }

        public popup2ViewModel(FirstViewModel parent) 
        {
            _parent = parent;
        }




        /////////////////////////////////////////////////////
        /// Used to demonstrate bindings work in the layout
        /////////////////////////////////////////////////////



        private string _title = "Second Popup Screen";
        public string Title
        {
            get { return _title; }
            set 
            { 
                _title = value; 
                RaisePropertyChanged(() => Title);
                RaisePropertyChanged(() => Both);
            }
        }

        private string _comment = "Check it out!";
        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                RaisePropertyChanged(() => Comment);
                RaisePropertyChanged(() => Both);
            }
        }


        public string Both
        {
            get { return _title + " " + _comment; }
        }
    }
}
