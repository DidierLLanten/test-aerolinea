using AutoMapper;
using WebApiAerolinea.DTOs;
using WebApiAerolinea.Entities;

namespace WebApiAerolinea.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
        }
    }
}
