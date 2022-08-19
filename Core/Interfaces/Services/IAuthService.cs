using Core.Entities;
using Core.ViewModels;
using Microsoft.AspNet.Identity;

namespace Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginViewModel user);

    }
}
