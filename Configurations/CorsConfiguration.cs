using Microsoft.Extensions.DependencyInjection;

namespace shop_backend.Configurations
{
    public static class CorsConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:3000")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowCredentials());
            });
        }
    }
}
