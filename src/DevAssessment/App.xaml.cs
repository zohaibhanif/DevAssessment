using AuthModule;
using AuthModule.Events;
using Common.Localization;
using DevAssessment.Resources;
using DevAssessment.Services;
using DryIoc;
using Prism;
using Prism.Events;
using Prism.Ioc;
using Prism.Logging;
using Prism.Modularity;
using Prism.Navigation;
using System;
using System.Linq;
using Xamarin.Forms;
using Prism.Services.Dialogs;
using DevAssessment.Views;
using DevAssessment.ViewModels;

namespace DevAssessment
{
    [AutoRegisterForNavigation]
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override Rules CreateContainerRules()
        {
            return base.CreateContainerRules().WithoutThrowOnRegisteringDisposableTransient();
        }

        protected async override void OnInitialized()
        {
            InitializeComponent();
            IEventAggregator eventAggregator = Container.Resolve<IEventAggregator>();
            eventAggregator.GetEvent<UserAuthenticatedEvent>().Subscribe(NavigateAuthenticatedUser);
            eventAggregator.GetEvent<LoggedOutEvent>().Subscribe(NavigateLoggedOutUser);

            var locale = Container.Resolve<ILocale>();
            var cultureInfo = locale.GetCurrentCultureInfo();
            AppResources.Culture = cultureInfo;
            locale.SetLocale(cultureInfo);

            await NavigationService.NavigateAsync("login");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILogger, ConsoleLoggingService>();
            containerRegistry.Register<IDialogService, DialogService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterSingleton<IMenuService, MenuService>();
            containerRegistry.RegisterDialog<AlertDialogView, AlertDialogViewModel>();
            containerRegistry.RegisterDialog<ErrorDialogView, ErrorDialogViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AuthenticationModule>();
            Type adminModuleInfo = typeof(AdminModule.AdminModule);
            moduleCatalog.AddModule(new ModuleInfo(adminModuleInfo)
            {
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
