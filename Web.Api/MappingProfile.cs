using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Web.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Booking, BookingDto>();
        CreateMap<BookingForCreationDto, Booking>();
        CreateMap<Room, RoomDto>();
        CreateMap<GuestDto, Guest>().ReverseMap();
        CreateMap<GuestForCreationDto, Guest>().ReverseMap();
    }
}

