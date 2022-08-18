using Application.Services.ServicesConfiguration;
using DataAccess.Repositories.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI.Mappers.Configuration;

namespace Chat.Configurations
{
    public static class ServicesConfiguration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddCustomRepositories();
            services.AddCustomMappers();
        }
    }
}
