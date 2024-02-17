using Microsoft.Extensions.DependencyInjection;
using shop_backend.Services.Auth;
using shop_backend.Services.Auth.Interfaces;
using shop_backend.Services.Interfaces;

namespace shop_backend.Services
{
    public static class ServicesInitializer
    {
        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IAddressService, AddressService>();
        }
    }
}
