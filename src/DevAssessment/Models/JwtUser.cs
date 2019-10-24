using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace DevAssessment.Models
{
    public class JwtUser
    {
        private string Jwt { get; }

        private List<Claim> Claims { get; }

        public JwtUser(string jwt)
        {
            Jwt = jwt;
            Claims = new JwtSecurityToken(Jwt).Claims.ToList();
        }

        public string Name => GetClaim("unique_name");

        public string Email => GetClaim("email");

        public string Role => GetClaim("role");

        private string GetClaim(string type)
        {
            return Claims.FirstOrDefault(x => x.Type == type)?.Value;
        }
    }
}
