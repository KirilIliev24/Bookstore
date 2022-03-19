using Bookstore.Core.Enums;
using BookstoreAPI.APIReqResModels.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreAPI.JWT
{
    public class JWTGenerator : IJWTGenerator
    {
        private readonly ApplicationSettings applicationSettings;

        public JWTGenerator(IOptions<ApplicationSettings> applicationSettings)
        {
            this.applicationSettings = applicationSettings.Value;
        }
        public string GenerateJwt(UserResponceModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Name, user.Username),
            };

            var isAdmin = user.Role.ToString().Contains(Enums.UserRole.Admin.ToString());
            var isManager = user.Role.ToString().Contains(Enums.UserRole.Manager.ToString());
            var isBasic = user.Role.ToString().Contains(Enums.UserRole.Basic.ToString());

            if (isAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, Enums.UserRole.Admin.ToString()));
            }
            if (isManager)
            {
                claims.Add(new Claim(ClaimTypes.Role, Enums.UserRole.Manager.ToString()));
            }
            if (isBasic)
            {
                claims.Add(new Claim(ClaimTypes.Role, Enums.UserRole.Basic.ToString()));
            }


            var secret = Encoding.UTF8.GetBytes(this.applicationSettings.Secret);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256));

            var tokenHandler = new JwtSecurityTokenHandler();
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
