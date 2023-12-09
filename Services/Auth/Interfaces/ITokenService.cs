using shop_backend.Http.Resources.Auth;
using System.Threading.Tasks;

namespace shop_backend.Services.Auth.Interfaces
{
    public interface ITokenService
    {
        TokenResource CreateTokens(string username, string role);

        string CreateaAccessToken(string username, string role);

        string CreateRefreshToken();

        Task SaveRefreshToken(int userId, string refreshToken);

        Task<bool> VerifyRefreshToken(string refreshToken);

        Task DeleteRefreshToken(string jwtRefreshToken);

    }
}
