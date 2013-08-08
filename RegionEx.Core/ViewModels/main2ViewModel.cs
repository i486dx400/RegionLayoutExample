using Cirrious.MvvmCross.ViewModels;

namespace RegionEx.Core.ViewModels
{
    public class main2ViewModel
        : MvxViewModel
    {
        // Allow access to navigation commands
        private FirstViewModel _parent;
        public FirstViewModel Parent { get { return _parent; } }
        
        public main2ViewModel(FirstViewModel parent) 
        {
            _parent = parent;
        }
    }
}
