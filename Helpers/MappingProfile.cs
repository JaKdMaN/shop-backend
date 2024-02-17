using AutoMapper;
using shop_backend.Http.Resources.Address;
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
                .ForMember(dest => dest.Adresses, opt => opt.MapFrom(src => src.UserAddresses))
                .ReverseMap();

            CreateMap<User, ProfileResource>().ReverseMap();

            CreateMap<UserRole, NameValueResource>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<UserAddress, AddressResource>().ReverseMap();
            CreateMap<UserAddress, AddressShortResource>().ReverseMap();
        }
    }
}
