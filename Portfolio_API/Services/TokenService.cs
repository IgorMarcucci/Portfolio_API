using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Portfolio_API;

public class TokenService : ITokenService
    {
        public TokenModel CreateToken(IdentityUser<int>? user, string jwtSecret) {
            var userRights = new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString()),
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(jwtSecret));
            SigningCredentials credentials = new SigningCredentials(key, 
                SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                claims: userRights,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddHours(8));

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new TokenModel(tokenString);
        }
    }
