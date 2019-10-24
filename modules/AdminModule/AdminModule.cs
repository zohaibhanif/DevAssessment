using AdminModule.ViewModels;
using AdminModule.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace AdminModule
{
    public class AdminModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AdminPage, AdminPageViewModel>();
        }
    }
}
