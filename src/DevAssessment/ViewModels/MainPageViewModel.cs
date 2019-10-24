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

namespace DevAssessment.ViewModels
{
    public class MainPageViewModel : BindableBase, IPageLifecycleAware
    {
        private IEventAggregator EventAggregator { get; }
        private IMenuService MenuService { get; }
        private INavigationService NavigationService { get; }
        private ILogger Logger { get; }

        public MainPageViewModel(INavigationService navigationService, ILogger logger, IMenuService menuService, IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            NavigationService = navigationService;
            MenuService = menuService;
            Logger = logger;
            MenuItems = new ObservableCollection<Item>(MenuService.MenuItems);

            LogoutCommand = new DelegateCommand(OnLogoutCommandExecuted);
            NavigationCommand = new DelegateCommand<Item>(OnNavigationCommandExecuted);
        }

        public IEnumerable<Item> MenuItems { get; }

        public bool IsPresented
        {
            get => _isPresented;
            set => SetProperty(ref _isPresented, value);
        }

        public bool _isPresented;

        public DelegateCommand LogoutCommand { get; }

        public DelegateCommand<Item> NavigationCommand { get; }

        private void OnLogoutCommandExecuted()
        {
            EventAggregator.GetEvent<LogoutRequestEvent>().Publish();
        }

        private async void OnNavigationCommandExecuted(Item item)
        {
            if (item.Name.Equals("Logout"))
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
        }

        public void OnDisappearing()
        {
        }
    }
}
