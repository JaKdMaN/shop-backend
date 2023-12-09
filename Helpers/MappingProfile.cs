using AutoMapper;
using shop_backend.Http.Resources.Misc;
using shop_backend.Http.Resources.User;
using shop_backend.Models;

namespace shop_backend.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserResource>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.UserRole))
                .ReverseMap();

            //UserRole
            CreateMap<UserRole, NameValueResource>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}
