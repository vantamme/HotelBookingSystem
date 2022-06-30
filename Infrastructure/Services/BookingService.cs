using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services;

public class BookingService : IBookingService
{
    private readonly IAppDbContext _context;
    private readonly IRoomService _roomService;
    private readonly ILogger<BookingService> _logger;
    private readonly IMapper _mapper;

    public BookingService(IAppDbContext context,
                          IRoomService roomService,
                          ILogger<BookingService> logger,
                          IMapper mapper)
    {
        _context = context;
        _roomService = roomService;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookingDto>?> GetRoomBookingsAsync(Guid roomId)
    {
        var room = await _roomService.GetRoomAsync(roomId);
        if (room == null) return null;
        var bookings = await _context.Bookings.FindByCondition(b => b.RoomId == roomId, trackChanges: false).ToListAsync();
        return _mapper.Map<IEnumerable<BookingDto>>(bookings);
    }

    public async Task<bool> UpdateBookingAsync(Guid roomId, Guid bookingId, BookingManipulationDto booking)
    {
        var room = await _roomService.GetRoomAsync(roomId);
        if (room == null) return false;
        var bookingEntity = await _context.Bookings.FindByCondition(b => b.Id == bookingId, trackChanges: true).SingleOrDefaultAsync();
        if (booking == null)
        {
            _logger.LogInformation($"Booking with id: {bookingId} doesn't exist in the database.");
            return false;
        }
        _mapper.Map(booking, bookingEntity);
        await _context.SaveChangesAsync();
        return true;
    }


    public async Task<BookingDto?> GetRoomBookingAsync(Guid roomId, Guid bookingId)
    {
        var room = await _roomService.GetRoomAsync(roomId);
        if (room == null) return null;
        var booking = await _context.Bookings.FindByCondition(b => b.Id == bookingId, trackChanges: false).SingleOrDefaultAsync();
        if (booking == null)
        {
            _logger.LogInformation($"Booking with id: {bookingId} doesn't exist in the database.");
            return null;
        }
        return _mapper.Map<BookingDto>(booking);
    }

    public async Task<bool> DeleteRoomBooking(Guid roomId, Guid bookingId)
    {
        var room = await _roomService.GetRoomAsync(roomId);
        if (room == null) return false;
        var booking = await _context.Bookings.FindByCondition(b => b.RoomId == roomId && b.Id == bookingId, trackChanges: false).SingleOrDefaultAsync();
        if (booking == null) return false;
        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<BookingDto?> CreateBookingForRoom(Guid roomId, BookingForCreationDto booking)
    {
        var room = await _roomService.GetRoomAsync(roomId);
        if (room == null) return null;
        var bookingEntity = _mapper.Map<Booking>(booking);
        bookingEntity.RoomId = roomId;
        _context.Bookings.Add(bookingEntity);
        await _context.SaveChangesAsync();
        return _mapper.Map<BookingDto>(bookingEntity);
    }

    public async Task<IEnumerable<BookingDto>?> GetGuestBookingsAsync(string email)
    {
        var bookings = await _context.Bookings.FindByCondition(b => b.Guest.Email == email, trackChanges: false).ToListAsync();
        return _mapper.Map<IEnumerable<BookingDto>>(bookings);
    }
}
