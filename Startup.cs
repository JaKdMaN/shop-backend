using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using shop_backend.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

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

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowOrigin");

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
