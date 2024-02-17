using AutoMapper;
using shop_backend.Exceptions;
using shop_backend.Http.Resources.User;
using shop_backend.Repositories.Interfaces;
using shop_backend.Services.Interfaces;
using System.Threading.Tasks;

namespace shop_backend.Services
{
    public class UserService: IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository) 
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserResource> GetMe(string jwtRefreshToken)
        {

            if (string.IsNullOrEmpty(jwtRefreshToken))
            {
                throw new HttpException("Вы не авторизованы", 401);
            }


            var user = await _userRepository.GetByToken(jwtRefreshToken);

            UserResource userResource = _mapper.Map<UserResource>(user);

            return userResource;
        }
    }
}
