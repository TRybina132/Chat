using Core.Interfaces.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Handlers
{
    public class JwtHandler : IJwtHandler
    {
        private readonly IConfiguration configuration;
        private readonly IConfigurationSection jwtSettings;

        public JwtHandler(IConfiguration configuration)
        {
            this.configuration = configuration;

            jwtSettings = configuration.GetSection("JWTConfig");
        }

        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> userClaims)
        {
            var lifetime = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["LifetimeInMinutes"]));

            var token = new JwtSecurityToken(
                issuer: jwtSettings["ValidIssuer"],
                audience: jwtSettings["ValidAudience"],
                claims: userClaims,
                expires: lifetime,
                signingCredentials: signingCredentials);

            return token;
        }

        //  ᓚᘏᗢ Things that will be stored in token
        public List<Claim> GetClaims(IdentityUser<int> user) =>
            new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString())
            };

        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);

            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
    }
}
