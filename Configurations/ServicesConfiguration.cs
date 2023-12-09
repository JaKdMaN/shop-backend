using Microsoft.Extensions.DependencyInjection;
using shop_backend.Database.Seeding.Interfaces;
using shop_backend.Database.Seeding.Seeders;
using shop_backend.Database.Seeding;
using shop_backend.Helpers;
using shop_backend.Services;
using shop_backend.Repositories;

namespace shop_backend.Configurations
{
    public static class ServicesConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            // Core
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();

            // Seeders
            services.AddTransient<ISeeder, UserRolesSeeder>();
            services.AddTransient<ISeeder, UserSeeder>();
            services.AddTransient<SeederFactory>();

            //Repositories
            services.InitializeRepositories();

            //Services
            services.InitializeServices();
        }
    }
}
