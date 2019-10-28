using AuthModule.Events;
using DevAssessment.Models;
using DevAssessment.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Essentials;
using Prism.AppModel;
using Prism.Modularity;
using DevAssessment.Resources;

namespace DevAssessment.ViewModels
{
    public class MainPageViewModel : BindableBase, IInitialize, IPageLifecycleAware
    {
        private IEventAggregator EventAggregator { get; }
        private IMenuService MenuService { get; }
        private INavigationService NavigationService { get; }
        private IModuleManager ModuleManager { get; }
        private ILogger Logger { get; }

        public MainPageViewModel(INavigationService navigationService, ILogger logger, IMenuService menuService, IEventAggregator eventAggregator, IModuleManager moduleManager)
        {
            EventAggregator = eventAggregator;
            NavigationService = navigationService;
            MenuService = menuService;
            Logger = logger;
            ModuleManager = moduleManager;

            LogoutCommand = new DelegateCommand(OnLogoutCommandExecuted);
            NavigationCommand = new DelegateCommand<Item>(OnNavigationCommandExecuted);
        }

        public IEnumerable<Item> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        private IEnumerable<Item> _menuItems;

        public bool IsPresented
        {
            get => _isPresented;
            set => SetProperty(ref _isPresented, value);
        }

        private bool _isPresented;

        public JwtUser JwtUser
        {
            get => _jwtUser;
            set => SetProperty(ref _jwtUser, value);
        }

        private JwtUser _jwtUser;

        public DelegateCommand LogoutCommand { get; }

        public DelegateCommand<Item> NavigationCommand { get; }

        private void OnLogoutCommandExecuted()
        {
            EventAggregator.GetEvent<LogoutRequestEvent>().Publish();
        }

        private async void OnNavigationCommandExecuted(Item item)
        {
            if (item.Name.Equals(AppResources.LabelLogout))
            {
                LogoutCommand.Execute();
            }
            else
            {
                await NavigationService.NavigateAsync($"NavigationPage/{item.Uri}");
            }
        }

        public void OnAppearing()
        {
            if (Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.TV || (Device.Idiom == TargetIdiom.Tablet && DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Landscape))
            {
                IsPresented = true;
            }

            if (JwtUser.Role.Equals(Role.Admin))
            {
                ModuleManager.LoadModule(nameof(AdminModule.AdminModule));
            }

            MenuService.Clear();
            MenuService.Load();
            MenuItems = new ObservableCollection<Item>(MenuService.MenuItems);
        }

        public void OnDisappearing()
        {
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (JwtUser is null)
            {
                var accessToken = parameters.GetValue<string>("accessToken");
                JwtUser = new JwtUser(accessToken);
            }
        }
    }
}
