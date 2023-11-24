using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using shop_backend.Configurations;
using shop_backend.Database;
using shop_backend.Database.Seeding;

namespace shop_backend
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            CorsConfiguration.Configure(services);
            DatabaseConfiguration.Configure(services, Configuration);
            ServicesConfiguration.Configure(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeederFactory seederFactory)
        {
            app.UseCors("AllowOrigin");

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
                seederFactory.SeedAll(context);
            }

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
