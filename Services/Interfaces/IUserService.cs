using shop_backend.Http.Resources.User;
using System.Threading.Tasks;

namespace shop_backend.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResource> GetMe(string jwtRefreshToken);
    }
}
