using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Mappings
{
    public class ContactSubCategoryMapingProfiles : Profile
    {
        public ContactSubCategoryMapingProfiles()
        {
            CreateMap<ContactSubCategoryCreateDto, ContactSubCategory>();
            CreateMap<ContactSubCategory, ContactSubCategoryGetDto>();
        }
    }
}
