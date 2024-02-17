using Microsoft.Extensions.DependencyInjection;
using shop_backend.Repositories.Interfaces;

namespace shop_backend.Repositories
{
    public static class RepositoriesInitializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserAddressRepository, UserAddressRepository>();
        }
    }
}
