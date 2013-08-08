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
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Droid.Views;

namespace RegionEx.Droid
{
    public interface IFragmentHost
    {
        bool Show(MvxViewModelRequest request);
    }

    public interface ICustomPresenter
    {
        void Register(Type viewModelType, IFragmentHost host);
    }



    class CustomPresenter : MvxAndroidViewPresenter, ICustomPresenter
    {
        // Map between view-model and fragment host which creates and 
        //   shows the view based on the view-model type
        private Dictionary<Type, IFragmentHost> dictionary = new Dictionary<Type, IFragmentHost>();

        public override void Show(MvxViewModelRequest request)
        {
            IFragmentHost host;
            if (this.dictionary.TryGetValue(request.ViewModelType, out host))
            {
                if (host.Show(request))
                {
                    return;
                }
            }
            base.Show(request);
        }


        public void Register(Type viewModelType, IFragmentHost host)
        {
            this.dictionary[viewModelType] = host;
        }
    }
}