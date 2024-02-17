using shop_backend.Http.Requests.User;
using shop_backend.Http.Resources.User;
using System.Threading.Tasks;

namespace shop_backend.Services.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileResource> GetProfile(string jwtRefreshToken);

        Task<ProfileResource> UpdateProfile(ProfileUpdateRequest profile);
    }
}
