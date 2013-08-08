using Cirrious.MvvmCross.ViewModels;

namespace RegionEx.Core.ViewModels
{
    public class main1ViewModel
        : MvxViewModel
    {
        // Allow access to navigation commands
        private FirstViewModel _parent;
        public FirstViewModel Parent { get { return _parent; } }
        
        public main1ViewModel(FirstViewModel parent) 
        {
            _parent = parent;
        }
    }
}
