using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using shop_backend.Http.Resources.Auth;
using shop_backend.Repositories.Interfaces;
using shop_backend.Services.Auth.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace shop_backend.Services.Auth
{
    public class TokenService: ITokenService
    {

        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public TokenService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;

        }

        public TokenResource CreateTokens(string username, string role)
        {
            return new TokenResource
            {
                AccessToken = CreateaAccessToken(username, role),
                RefreshToken = CreateRefreshToken()
            };
        }

        public async Task SaveRefreshToken(int userId,  string refreshToken)
        {
            var user = await _userRepository.GetById(userId);
            user.RefreshToken = refreshToken;
            await _userRepository.Update(user);
        }

        public string CreateaAccessToken(string username, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Role, role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expire = _configuration.GetSection("Jwt:Expire").Get<int>();

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.UtcNow.AddMinutes(expire),
                claims: claims,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string CreateRefreshToken()
        {
            var randomNumber = new byte[64];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }

        public async void RevokeRefreshToken(int userId)
        {
            var user = await _userRepository.GetById(userId);

            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }
            user.RefreshToken = null;

            await _userRepository.Update(user);
        }

        public async Task<bool> VerifyRefreshToken(string jwtRefreshToken)
        {
            var user = await _userRepository.GetByToken(jwtRefreshToken);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        public async Task DeleteRefreshToken(string jwtRefreshToken)
        {
            var user = await _userRepository.GetByToken(jwtRefreshToken);
            user.RefreshToken = null;
            await _userRepository.Update(user);
        }
    }
}
