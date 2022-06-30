using Application;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services;

public class RoomService : IRoomService
{
    private readonly IAppDbContext _context;
    private readonly ILogger<IRoomService> _logger;
    private readonly IMapper _mapper;

    public RoomService(IAppDbContext context, ILogger<IRoomService> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RoomDto>> GetAllRoomsAsync()
    {
        var rooms = await _context.Rooms.FindAll(trackChanges: false).ToListAsync();
        return _mapper.Map<IEnumerable<RoomDto>>(rooms);
    }

    public async Task<RoomDto?> GetRoomAsync(Guid roomId)
    {
        var room = await _context.Rooms.FindByCondition(r => r.Id == roomId, trackChanges: false).SingleOrDefaultAsync();
        if (room == null)
        {
            _logger.LogInformation($"Room with id: {roomId} doesn't exist in the database.");
            return null;
        }
        return _mapper.Map<RoomDto>(room);
    }

    public async Task<IEnumerable<RoomDto>> GetAvailableRooms(BookingPeriod period)
    {
        if (!(DateTime.TryParse(period.CheckIn, out var checkIn) && DateTime.TryParse(period.CheckOut, out var checkOut)))
            return Enumerable.Empty<RoomDto>();
        var rooms = await _context.Rooms.FindByCondition(r => !r.Bookings.Any(b => checkIn < b.CheckOut && checkOut > b.CheckIn), trackChanges: false).ToListAsync();
        return _mapper.Map<IEnumerable<RoomDto>>(rooms);
    }

}
