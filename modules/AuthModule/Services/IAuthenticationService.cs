using MockAuthentication.Models;
using System.Threading.Tasks;

namespace AuthModule.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> LoginAsync(string username, string password);
        Task LogoutAsync();
    }
}
