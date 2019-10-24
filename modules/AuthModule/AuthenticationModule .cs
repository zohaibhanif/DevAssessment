using AuthModule.Events;
using AuthModule.Services;
using AuthModule.ViewModels;
using AuthModule.Views;
using MockAuthentication.Services;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;

namespace AuthModule
{
    public class AuthenticationModule : IModule
    {
        private IAuthenticationService AuthenticationService { get; set; }
        private IEventAggregator EventAggregator { get; set; }

        public AuthenticationModule()
        {
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            AuthenticationService = containerProvider.Resolve<IAuthenticationService>();
            EventAggregator = containerProvider.Resolve<IEventAggregator>();

            EventAggregator.GetEvent<LogoutRequestEvent>().Subscribe(ExecuteLogoutRequest);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IAuthenticationService, AuthenticationService>();
            containerRegistry.Register<IJwtService, JwtService>();
            containerRegistry.Register<IUserService, MockUserService>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>("login");
        }

        private async void ExecuteLogoutRequest()
        {
            await AuthenticationService.LogoutAsync();

            EventAggregator.GetEvent<LoggedOutEvent>().Publish();
        }
    }
}
