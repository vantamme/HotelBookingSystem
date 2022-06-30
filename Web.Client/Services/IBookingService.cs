using Web.Client.Models;

namespace Web.Client.Services;

public interface IBookingService
{
    Task BookRoomAsync(Guid roomId, CreateBookingModel booking);
    Task DeleteBooking(Guid roomId, Guid bookingId);
    Task<BookingModel?> GetRoomBookingAsync(Guid roomId, Guid bookingId);
    Task<IEnumerable<BookingModel>> GetRoomBookingsAsync(Guid roomId);
    Task<IEnumerable<BookingModel>> GetUserBookingsAsync(string userName);
    Task UpdateRoomBooking(Guid roomId, Guid bookingId, EditBookingModel booking);
}