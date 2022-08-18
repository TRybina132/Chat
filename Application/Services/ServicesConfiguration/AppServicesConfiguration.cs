using Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services.ServicesConfiguration
{
    public static class AppServicesConfiguration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
