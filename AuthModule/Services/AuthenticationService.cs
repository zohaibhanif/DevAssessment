using MockAuthentication.Models;
using MockAuthentication.Services;
using Prism.Logging;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AuthModule.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private const string AccessTokenKey = "AccessToken";
        private IUserService UserService { get; }
        private ILogger Logger { get; }

        public AuthenticationService(IUserService userService, ILogger logger)
        {
            UserService = userService;
            Logger = logger;
        }

        public async Task<AuthenticationResult> LoginAsync(string username, string password)
        {
            AuthenticationResult result = null;
            result = UserService.Login(username, password);

            if (result.IsAuthenticated)
            {
                try
                {
                    await SecureStorage.SetAsync(AccessTokenKey, result.AccessToken);
                }
                catch (Exception ex)
                {
                    Logger.Report(ex);
                }
            }

            return result;
        }

        public async Task LogoutAsync()
        {
            try
            {
                string accessToken = await SecureStorage.GetAsync(AccessTokenKey);

                if (!(accessToken is null))
                {
                    SecureStorage.Remove(AccessTokenKey);
                }
            }
            catch (Exception ex)
            {
                Logger.Report(ex);
            }
        }
    }
}
