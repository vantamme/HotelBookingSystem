using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[Route("api/guests")]
[ApiController]
public class GuestsController : ControllerBase
{
    public IGuestService _guestService;
    public IBookingService _bookingService;

    public GuestsController(IGuestService guestService, IBookingService bookingService)
    {
        _guestService = guestService;
        _bookingService = bookingService;
    }

    [HttpGet("{id}", Name = "GetGuest")]
    public async Task<IActionResult> GetGuest(Guid id)
    {
        var guestDto = await _guestService.GetGuestAsync(id);
        return guestDto != null ? Ok(guestDto) : NotFound();
    }

    [HttpGet("{userName}/bookings")]
    public async Task<IActionResult> GetGuestBookings(string userName)
    {
        var bookings = await _bookingService.GetGuestBookingsAsync(userName);
        return bookings != null ? Ok(bookings) : NotFound();
    }
}
