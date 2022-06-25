using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Mappings
{
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<UserCreateDto, User>();

            CreateMap<Contact, uint>().ConvertUsing(x => x.Id);
            CreateMap<User, UserGetDto>()
                .ForMember(dest => dest.ContactsIds,
                opt => opt.MapFrom(src => src.Contacts));
        }
    }
}
