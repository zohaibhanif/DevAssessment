using AuthModule;
using AuthModule.Events;
using Prism;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Logging;
using Xamarin.Forms;
using DevAssessment.Services;
using System;
using Prism.Navigation;
using System.Linq;

namespace DevAssessment
{
    [AutoRegisterForNavigation]
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected async override void OnInitialized()
        {
            InitializeComponent();

            IEventAggregator eventAggregator = Container.Resolve<IEventAggregator>();
            eventAggregator.GetEvent<UserAuthenticatedEvent>().Subscribe(NavigateAuthenticatedUser);
            eventAggregator.GetEvent<LoggedOutEvent>().Subscribe(NavigateLoggedOutUser);

            await NavigationService.NavigateAsync("login");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILogger, ConsoleLoggingService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterSingleton<IMenuService, MenuService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AuthenticationModule>();
            Type adminModuleInfo = typeof(AdminModule.AdminModule);
            moduleCatalog.AddModule(new ModuleInfo(adminModuleInfo) { 
                ModuleName = adminModuleInfo.Name,
                InitializationMode = InitializationMode.OnDemand
            });
        }

        private async void NavigateAuthenticatedUser(string accessToken)
        {
            await NavigationService.NavigateAsync("/MainPage/NavigationPage/DashboardPage", ("accessToken", accessToken));
        }

        private async void NavigateLoggedOutUser()
        {
            var modules = Container.Resolve<IModuleCatalog>().Modules.ToList();
            var adminModule = modules.FirstOrDefault(x => x.ModuleName == nameof(AdminModule.AdminModule));

            if (!(adminModule is null))
            {
                adminModule.State = ModuleState.NotStarted;
            };
            await NavigationService.NavigateAsync("/login");
        }
    }
}
