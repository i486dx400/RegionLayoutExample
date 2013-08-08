using Cirrious.MvvmCross.ViewModels;

namespace RegionEx.Core.ViewModels
{
    public class nav1ViewModel
        : MvxViewModel
    {
        // Allow access to navigation commands
        private FirstViewModel _parent;
        public FirstViewModel Parent { get { return _parent; } }

        public nav1ViewModel(FirstViewModel parent) 
        {
            _parent = parent;
        }
    }
}
