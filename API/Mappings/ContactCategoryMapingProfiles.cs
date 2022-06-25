using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Mappings
{
    public class ContactCategoryMapingProfiles : Profile
    {
        public ContactCategoryMapingProfiles()
        {
            CreateMap<ContactCategoryCreateDto, ContactCategory>();
            CreateMap<ContactCategory, ContactCategoryGetDto>();
        }
    }
}
