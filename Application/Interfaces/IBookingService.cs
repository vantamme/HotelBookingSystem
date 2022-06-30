using Application.DTOs;

namespace Application.Interfaces;

public interface IBookingService
{
    Task<bool> DeleteRoomBooking(Guid roomId, Guid bookingId);
    Task<BookingDto?> GetRoomBookingAsync(Guid roomId, Guid bookingId);
    Task<IEnumerable<BookingDto>?> GetRoomBookingsAsync(Guid roomId);
    Task<BookingDto?> CreateBookingForRoom(Guid roomId, BookingForCreationDto booking);
    Task<IEnumerable<BookingDto>?> GetGuestBookingsAsync(string email);
    Task<bool> UpdateBookingAsync(Guid roomId, Guid bookingId, BookingManipulationDto booking);
}
