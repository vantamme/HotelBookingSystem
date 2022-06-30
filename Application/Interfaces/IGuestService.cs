using Application.DTOs;

namespace Application.Interfaces;

public interface IGuestService
{
    Task<GuestDto?> GetGuestAsync(Guid id);
}