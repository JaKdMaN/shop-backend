using Microsoft.Extensions.DependencyInjection;
using shop_backend.Database.Seeding.Interfaces;
using shop_backend.Database.Seeding.Seeders;
using shop_backend.Database.Seeding;

namespace shop_backend.Configurations
{
    public static class ServicesConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            // Seeders
            services.AddTransient<ISeeder, UserRolesSeeder>();
            services.AddTransient<ISeeder, UserSeeder>();
            services.AddTransient<SeederFactory>();

            // Other
            services.AddControllers();
        }
    }
}
