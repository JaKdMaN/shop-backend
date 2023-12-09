using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace shop_backend.Configurations
{
    public static class CookiConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "Name";
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromMinutes(60);
            });
        }
    }
}
