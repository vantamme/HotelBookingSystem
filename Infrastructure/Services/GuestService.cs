using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services;

public class GuestService : IGuestService
{
    private readonly IAppDbContext _context;
    private readonly ILogger<BookingService> _logger;
    private readonly IMapper _mapper;

    public GuestService(IAppDbContext context,
                          ILogger<BookingService> logger,
                          IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<GuestDto?> GetGuestAsync(Guid id)
    {
        var guest = await _context.Guests.FindByCondition(g => g.Id == id, trackChanges: false).SingleOrDefaultAsync();
        if (guest == null)
        {
            _logger.LogInformation($"Guest with id: {id} doesn't exist in the database.");
            return null;
        }
        return _mapper.Map<GuestDto>(guest);
    }

    public async Task<GuestDto> CreateGuest(GuestForCreationDto guestDto)
    {
        var guest = _mapper.Map<Guest>(guestDto);
        _context.Guests.Add(guest);
        await _context.SaveChangesAsync();
        return _mapper.Map<GuestDto>(guest);
    }
}
