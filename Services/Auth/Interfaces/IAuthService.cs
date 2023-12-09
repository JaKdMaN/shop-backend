using shop_backend.Http.Requests.Auth;
using shop_backend.Http.Resources.User;
using System.Threading.Tasks;

namespace shop_backend.Services.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<UserResource> Register(RegisterRequest entity);

        Task<UserResource> Login(LoginRequest entity);

        Task<bool> Logout(string jwtRefreshToken);

        Task<UserResource> Refresh(string jwtRefreshToken);

        bool VerifyPassword(string enteredPassword, string storedPassword);
    }
}
