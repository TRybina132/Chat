using Core.Entities;
using Core.Interfaces.Handlers;
using Core.Interfaces.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtHandler jwtHandler;
        private readonly UserManager<User> userManager;

        public AuthService(UserManager<User> manager, IJwtHandler jwtHandler)
        {
            this.jwtHandler = jwtHandler;
            userManager = manager;
        }

        public async Task<string> Login(LoginViewModel login)
        {
            var user = await userManager.FindByNameAsync(login.Username);

            if (user == null || !await userManager.CheckPasswordAsync(user, login.Password))
                return "";

            var signingCredentials = jwtHandler.GetSigningCredentials();

            var claims = jwtHandler.GetClaims(user);

            var tokenOptions = jwtHandler.GenerateTokenOptions(signingCredentials, claims);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }
    }
}
