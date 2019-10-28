using AdminModule.Resources;
using AdminModule.ViewModels;
using AdminModule.Views;
using Common.Localization;
using Prism.Ioc;
using Prism.Modularity;

namespace AdminModule
{
    public class AdminModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var cultureInfo = containerProvider.Resolve<ILocale>().GetCurrentCultureInfo();
            AppResources.Culture = cultureInfo;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AdminPage, AdminPageViewModel>();
        }
    }
}
