using Application.Handlers;
using Application.Providers;
using Application.Services.ServicesConfiguration;
using Core.Interfaces.Handlers;
using DataAccess.Repositories.Configuration;
using Microsoft.AspNetCore.SignalR;
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
            services.AddTransient<IUserIdProvider, UserIdProvider>();
        }

        public static void AddCors(this IServiceCollection services, IConfigurationSection corsConfig)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: corsConfig["Name"],
                    policy =>
                    {
                        policy.WithOrigins(corsConfig["Origin"]);
                        policy.WithHeaders(corsConfig["Headers"]);
                        policy.WithMethods(corsConfig["Methods"]);
                        policy.AllowCredentials();
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                    });
            });
        }
    }
}
