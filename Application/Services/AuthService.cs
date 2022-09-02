using Core.Entities;
using Core.Interfaces.Handlers;
using Core.Interfaces.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Services
{
    //  ᓚᘏᗢ Start implementing token Controller
    public class AuthService : IAuthService
    {
        private readonly IJwtHandler jwtHandler;
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;

        public AuthService(
            UserManager<User> manager,
            IJwtHandler jwtHandler,
            IUserService userService)
        {
            this.userService = userService;
            this.jwtHandler = jwtHandler;
            userManager = manager;
        }

        public async Task<LoginResponse> Login(LoginViewModel login)
        {
            var user = await userManager.FindByNameAsync(login.Username);

            if (user == null || !await userManager.CheckPasswordAsync(user, login.Password))
                return new LoginResponse 
                    { 
                        ErrorMessage = "Username or password are incorrect!",
                        IsSuccessful = false
                    };

            var signingCredentials = jwtHandler.GetSigningCredentials();

            var claims = jwtHandler.GetClaims(user);

            var tokenOptions = jwtHandler.GenerateTokenOptions(signingCredentials, claims);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            var refreshToken = jwtHandler.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(4);

            //  POTENTIAL BUG! MAY NOT ALTER DATA in DB
            await userManager.UpdateAsync(user);

            return new LoginResponse
            {
                IsSuccessful = true,
                Token = token,
                RefreshToken = refreshToken
            };
        }

        public async Task<LoginResponse> RefreshToken(string expired, string refresh)
        {
            var principal = jwtHandler.GetPrincipalFromExpiredToken(expired);
            var user = await userService.GetByUsername(principal.FindFirst("username").Value);

            if (user.RefreshToken == null
                || user.RefreshToken != refresh
                || user.RefreshTokenExpiryTime <= DateTime.Now)
                    throw new Exception("Refresh token not valid!");

            var tokenOptions = jwtHandler.GenerateTokenOptions(jwtHandler.GetSigningCredentials(), principal.Claims.ToList());
            var newRefresh = jwtHandler.GenerateRefreshToken();

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            user.RefreshToken = newRefresh;

            await userManager.UpdateAsync(user);

            return new LoginResponse
            {
                Token = token,
                RefreshToken = newRefresh
            };
        }
    }
}
