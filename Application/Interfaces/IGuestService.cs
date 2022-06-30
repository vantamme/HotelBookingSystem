using Application.DTOs;

namespace Application.Interfaces;

public interface IGuestService
{
    Task<GuestDto> CreateGuest(GuestForCreationDto guestDto);
    Task<GuestDto?> GetGuestAsync(Guid id);
}