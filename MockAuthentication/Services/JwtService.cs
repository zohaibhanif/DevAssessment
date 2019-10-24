using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MockAuthentication.Services
{
    public class JwtService : IJwtService
    {
        private string SecretKey { get; }
        private string SecurityAlgorithm { get; }
        private int ExpireMinutes { get; }

        public JwtService()
        {
            ExpireMinutes = 720;
            SecretKey = "TW9zaGVFcmV6UHJpdmF0ZUtleQ==";
            SecurityAlgorithm = SecurityAlgorithms.HmacSha256Signature;
        }

        public string GenerateToken(List<Claim> claims)
        {
            if (claims == null || claims.Count == 0)
            {
                throw new ArgumentException("Arguments to create token are not valid.");
            }

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(ExpireMinutes),
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithm)
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            string token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return token;
        }

        private SecurityKey GetSymmetricSecurityKey()
        {
            byte[] symmetricKey = Convert.FromBase64String(SecretKey);
            return new SymmetricSecurityKey(symmetricKey);
        }
    }
}
