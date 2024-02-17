using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using shop_backend.Exceptions;
using shop_backend.Helpers;
using shop_backend.Http.Requests.Auth;
using shop_backend.Http.Resources.User;
using shop_backend.Models;
using shop_backend.Repositories.Interfaces;
using shop_backend.Services.Auth.Interfaces;
using System;
using System.Threading.Tasks;

namespace shop_backend.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly ITokenService _tokenService;

        public AuthService(
            IMapper mapper,
            IUserRepository userRepository,
            IUserRoleRepository userRoleRepository,
            ITokenService tokenService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _tokenService = tokenService;
        }

        public async Task<UserResource> Register(RegisterRequest registerUserRequest)
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(u => u.Email == registerUserRequest.username);
            var defaultRole = await _userRoleRepository.GetById(2);

            if (user != null)
            {
                throw new HttpException("Пользователь с таким логином уже существует", 401);
            }

            var newUser = new User
            {
                Email = registerUserRequest.username,
                Password = HashPasswordHelper.HashPassword(registerUserRequest.password),
                UserRole = defaultRole,
            };

            await _userRepository.Create(newUser);

            var userResource = _mapper.Map<UserResource>(newUser);

            return userResource;
        }

        public async Task<UserResource> Login(LoginRequest loginUserRequst)
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Email == loginUserRequst.Username);

            if (user != null)
            {
                var userResource = _mapper.Map<UserResource>(user);

                if (VerifyPassword(loginUserRequst.Password, user.Password))
                {
                    return userResource;
                } else
                {
                    throw new HttpException("Неверный пароль", 427);
                }

            } else
            {
                throw new HttpException("Пользователя с таким логином не существует", 401);
            }

        }

        public async Task<bool> Logout(string jwtRefreshToken)
        {
            await _tokenService.DeleteRefreshToken(jwtRefreshToken);

            return true;
        }

        public async Task<UserResource> Refresh(string jwtRefreshToken)
        {
            if (string.IsNullOrEmpty(jwtRefreshToken))
            {
                throw new HttpException("Вы не авторизованы", 401);
            }

            var isVerifiedtoken = await _tokenService.VerifyRefreshToken(jwtRefreshToken);

            if (!isVerifiedtoken)
            {
                throw new HttpException("Вы не авторизованы", 401);
            }

            var user = await _userRepository.GetByToken(jwtRefreshToken);
            var userResource = _mapper.Map<UserResource>(user);

            return userResource;
        }



        public bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            return storedPassword == HashPasswordHelper.HashPassword(enteredPassword);
        }
    }
}
