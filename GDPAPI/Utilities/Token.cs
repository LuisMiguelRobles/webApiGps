using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GDPAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GDPAPI.Utilities
{
    public class Token :IToken
    {
        private readonly IConfiguration _configuration;
        public Token(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetToken(User user)
        {
            var key = GetKey();
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

        private byte[] GetKey()
        {
            var secretKey = _configuration.GetValue<string>("JWT:secretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);
            return key;
        }
    }
}
