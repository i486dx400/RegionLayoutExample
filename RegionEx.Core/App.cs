using Cirrious.CrossCore.IoC;

namespace RegionEx.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
            // Start with the loading screen
            RegisterAppStart<ViewModels.LoadingScreenViewModel>();
        }
    }
}