using AutoMapper;
using shop_backend.Exceptions;
using shop_backend.Http.Requests.User;
using shop_backend.Http.Resources.User;
using shop_backend.Repositories.Interfaces;
using shop_backend.Services.Interfaces;
using System.Threading.Tasks;

namespace shop_backend.Services
{
    public class ProfileService: IProfileService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public ProfileService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ProfileResource> GetProfile(string jwtRefreshToken)
        {
            var user = await _userRepository.GetByToken(jwtRefreshToken);

            if (user == null)
            {
                throw new HttpException("Вы не авторизованы", 401);
            }

            var profileResource = _mapper.Map<ProfileResource>(user);

            return profileResource;
        }

        public async Task<ProfileResource> UpdateProfile(ProfileUpdateRequest profile)
        {
            var user = await _userRepository.GetByEmail(profile.Email);

            if (user == null)
            {
                throw new HttpException("Вы не авторизованы", 401);
            }

            user.Name = profile.Name;
            user.Surname = profile.Surname;
            user.Email = profile.Email;
            user.PhoneNumber = profile.PhoneNumber;

            await _userRepository.Update(user);

            var profileResource = _mapper.Map<ProfileResource>(user);

            return profileResource;
        }
    }
}
