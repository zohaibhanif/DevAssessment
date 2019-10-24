using MockAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MockAuthentication.Services
{
    public class MockUserService : IUserService
    {
        private const string InvalidUserMessage = "Login falied. Provided Username or Password is not valid";
        private IList<User> UserList { get; }
        private IJwtService JwtService { get; }

        public MockUserService(IJwtService jwtService)
        {
            JwtService = jwtService;

            UserList = new List<User>()
            {
                new User(){ Name = "Zohaib", Email = "zohaib.hanif@nxb.com.pk", Password = "test123", Role = AppRole.Admin },
                new User(){ Name = "Ali", Email = "zohaib@avantipoint.com", Password = "test", Role = AppRole.User },
                new User(){ Name = "Awais", Email = "zohaib.avantipoint@nxvt.com", Password = "test123", Role = AppRole.User }
            };
        }

        public AuthenticationResult Login(string username, string password)
        {
            AuthenticationResult result = new AuthenticationResult();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                result.ErrorMessage = InvalidUserMessage;
                return result;
            }

            var user = UserList.FirstOrDefault(x => x.Email.Equals(username.Trim(), StringComparison.OrdinalIgnoreCase) && x.Password.Equals(password));

            if (user is null)
            {
                result.ErrorMessage = InvalidUserMessage;
                return result;
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            result.IsAuthenticated = true;
            result.AccessToken = JwtService.GenerateToken(claims);

            return result;
        }
    }
}
