using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using shop_backend.Database.Seeding;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using shop_backend.Configurations;
using shop_backend.Database;
using shop_backend.Http.Middleware;

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
            DatabaseConfiguration.Configure(services, Configuration);
            AuthConfiguration.Configure(services, Configuration);
            CookiConfiguration.Configure(services);
            CorsConfiguration.Configure(services);
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

            app.UseMiddleware<Auth>();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
