using MockAuthentication.Models;

namespace MockAuthentication.Services
{
    public interface IUserService
    {
        AuthenticationResult Login(string username, string password);
    }
}
