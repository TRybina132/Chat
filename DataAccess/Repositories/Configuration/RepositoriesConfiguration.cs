using Core.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Configuration
{
    public static class RepositoriesConfiguration
    {
        public static void AddCustomRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
        }
    }
}
