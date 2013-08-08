using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.Plugins.Visibility;
using Cirrious.MvvmCross.ViewModels;

namespace RegionEx.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            // Register the custom presenter
            var regionPresenter = new CustomPresenter();
            Mvx.RegisterSingleton<ICustomPresenter>(regionPresenter);
            return regionPresenter;
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new MvxDebugTrace();
        }

        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            // Load the visibility converter so it can be called from the
            //   layout bindings
            pluginManager.EnsurePluginLoaded<PluginLoader>();
            pluginManager.EnsurePluginLoaded<Cirrious.MvvmCross.Plugins.Visibility.PluginLoader>();
            base.LoadPlugins(pluginManager);
        }
    }
}