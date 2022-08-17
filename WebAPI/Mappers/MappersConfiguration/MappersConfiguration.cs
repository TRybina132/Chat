using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Mappers.Configuration
{
    public static class MappersConfiguration
    {
        public static void AddCustomMappers(this IServiceCollection services)
        {
            services.AddScoped<IMapper<User, UserViewModel>, UserViewModelMapper>();
            services.AddScoped<IMapper<IEnumerable<User>, IEnumerable<UserViewModel>>, UsersViewModelMapper>();
        }
    }
}
