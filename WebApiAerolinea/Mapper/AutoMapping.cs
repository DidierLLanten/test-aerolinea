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

            CreateMap<Seat, CreateSeatDto>().ReverseMap();
            CreateMap<Seat, UpdateSeatDto>().ReverseMap();

            CreateMap<Flight, CreateFlightDto>().ReverseMap();
            CreateMap<UpdateFlightDto, Flight>()
                .ForMember(dest => dest.Airline, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Airline)))
                .ForMember(dest => dest.FlightNumber, opt => opt.Condition(src => !string.IsNullOrEmpty(src.FlightNumber)))
                .ForMember(dest => dest.Origin, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Origin)))
                .ForMember(dest => dest.Destination, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Destination)))
                .ForMember(dest => dest.DepartureTime, opt => opt.Condition(src => src.DepartureTime.HasValue))
                .ForMember(dest => dest.ArrivalTime, opt => opt.Condition(src => src.ArrivalTime.HasValue));
        }
    }
}
