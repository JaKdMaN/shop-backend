using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using shop_backend.Database;
using shop_backend.Database.Seeding;
using shop_backend.Database.Seeding.Interfaces;
using shop_backend.Database.Seeding.Seeders;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Threading.Tasks;

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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:3000")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowCredentials());
            });

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ShopDbContext>(options =>
            {
                options.UseMySql(connection, ServerVersion.AutoDetect(connection));
            });

            services.AddTransient<ISeeder, UserRolesSeeder>();
            services.AddTransient<ISeeder, UserSeeder>();

            services.AddTransient<SeederFactory>();

            services.AddControllers();
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
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
