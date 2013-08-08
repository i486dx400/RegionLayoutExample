using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;

namespace RegionEx.Core.ViewModels
{
    public class LoadingScreenViewModel 
		: MvxViewModel
    {
        public ICommand LoadFinishedCommand
        {
            get { return new MvxCommand(() => ShowViewModel<FirstViewModel>()); }
        }   
    }
}
