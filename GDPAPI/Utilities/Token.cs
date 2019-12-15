using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GDPAPI.Models;
using GDPAPI.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace GDPAPI.Utilities
{
    public class Token :IToken
    {
        public Token()
        {
            
        }

        public string GetToken(User user, byte[] key)
        {
            if (user == null || key == null) return string.Empty;
            var tokenHandler = new JwtSecurityTokenHandler();
            var createToken = tokenHandler.CreateToken(GetSecurityTokenDescriptor(key, user));
            var token = tokenHandler.WriteToken(createToken);
            return token;
        }


        private ClaimsIdentity GetUserClaims(User user)
        {
            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.LastName ),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("city", user.City),
                new Claim(ClaimTypes.Role, user.UserType.ToString()),
                new Claim("phone", user.Phone)
            });

            return claims;
        }

        private SecurityTokenDescriptor GetSecurityTokenDescriptor(byte[] key, User user)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GetUserClaims(user),

                Expires = DateTime.UtcNow.AddMinutes(2),

                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            return tokenDescriptor;
        }
    }
}
