using AutoMapper;
using Domain.Entities;
using Web.Client.Models;

namespace Web.Client;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GuestModel, Guest>();
        CreateMap<BookingModel, EditBookingModel>();
    }
}

