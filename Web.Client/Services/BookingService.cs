using Web.Client.Models;

namespace Web.Client.Services;

public class BookingService : IBookingService
{
    private readonly HttpClient _client;
    private readonly IUserService _userService;

    public BookingService(IHttpClientFactory factory, IUserService userService)
    {
        _client = factory.CreateClient("hotel");
        _userService = userService;
    }

    public async Task BookRoomAsync(Guid roomId, CreateBookingModel booking) => 
        await _client.PostAsJsonAsync(GetPath(roomId), booking);

    public async Task<IEnumerable<BookingModel>> GetUserBookingsAsync(string userName)
    {
        var bookings = await _client.GetFromJsonAsync<BookingModel[]>($"api/guests/{userName}/bookings");
        return bookings ?? Enumerable.Empty<BookingModel>();
    }

    public async Task<IEnumerable<BookingModel>> GetRoomBookingsAsync(Guid roomId)
    {
        var bookings = await _client.GetFromJsonAsync<BookingModel[]>(GetPath(roomId));
        return bookings ?? Enumerable.Empty<BookingModel>();
    }

    public async Task<BookingModel?> GetRoomBookingAsync(Guid roomId, Guid bookingId)
    {
        var booking = await _client.GetFromJsonAsync<BookingModel>(GetPath(roomId, bookingId));
        if (booking != null)
            booking.Guest = await _userService.GetGuestAsync(booking.GuestId);
        return booking;
    }

    public async Task UpdateRoomBooking(Guid roomId, Guid bookingId, EditBookingModel booking) => 
        await _client.PutAsJsonAsync(GetPath(roomId, bookingId), booking);

    public async Task DeleteBooking(Guid roomId, Guid bookingId) => 
        await _client.DeleteAsync(GetPath(roomId, bookingId));

    private string GetPath(Guid roomId, Guid? bookingId = null) =>
        $"api/rooms/{roomId}/bookings/{bookingId}";
}
