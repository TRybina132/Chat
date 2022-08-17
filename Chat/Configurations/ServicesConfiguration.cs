using DataAccess.Repositories.Configuration;

namespace Chat.Configurations
{
    public static class ServicesConfiguration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddCustomRepositories();
        }
    }
}
