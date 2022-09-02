using Core.ViewModels;

namespace Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginViewModel user);
        Task<LoginResponse> RefreshToken(string expired, string refresh);
    }
}
