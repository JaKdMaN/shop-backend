using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using shop_backend.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace shop_backend.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ShopDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }
    }
}
