using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Mappings
{
    public class ContactMapingProfiles : Profile
    {
        public ContactMapingProfiles()
        {
            CreateMap<ContactCreateDto, Contact>();
            CreateMap<Contact, ContactGetDto>();
        }
    }
}
