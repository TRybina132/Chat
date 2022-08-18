using Application.Handlers;
using Application.Services.ServicesConfiguration;
using Core.Interfaces.Handlers;
using DataAccess.Repositories.Configuration;
using WebAPI.Mappers.Configuration;
using WebAPI.Validators.Configuration;

namespace Chat.Configurations
{
    public static class ServicesConfiguration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddCustomRepositories();
            services.AddCustomMappers();

            services.AddFluentValidators();

            services.AddScoped<IJwtHandler, JwtHandler>();
        }
    }
}
