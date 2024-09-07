using AutoMapper;
using DAL.Entities;
using WebApiAerolinea.DTOs;

namespace WebApiAerolinea.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
        }
    }
}
