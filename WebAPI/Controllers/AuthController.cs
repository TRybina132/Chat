using Core.Interfaces.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<LoginResponse> LoginAsync([FromBody] LoginViewModel credentials) =>
            await authService.Login(credentials);

        [HttpPost("refresh")]
        public async Task<LoginResponse> Refresh(TokenViewModel token) =>
            await authService.RefreshToken(token.AccessToken, token.RefreshToken);
    }
}
