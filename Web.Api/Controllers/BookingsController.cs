using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[Route("api/rooms/{roomId}/bookings")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookingForRoom(Guid roomId, [FromBody] BookingForCreationDto booking)
    {
        var bookingDto = await _bookingService.CreateBookingForRoom(roomId, booking);
        return CreatedAtRoute("GetRoomBooking", new { roomId, id = bookingDto!.Id }, bookingDto);
    }

    [HttpGet("{id}", Name = "GetRoomBooking")]
    public async Task<IActionResult> GetRoomBooking(Guid roomId, Guid id)
    {
        var bookingDto = await _bookingService.GetRoomBookingAsync(roomId, id);
        return bookingDto != null ? Ok(bookingDto) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetRoomBookings(Guid roomId)
    {
        var bookings = await _bookingService.GetRoomBookingsAsync(roomId);
        return bookings != null ? Ok(bookings) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoomBooking(Guid roomId, Guid id)
    {
        var isDeleted = await _bookingService.DeleteRoomBooking(roomId, id);
        return isDeleted ? NoContent() : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBooking(Guid roomId, Guid id, [FromBody] BookingForCreationDto booking)
    {
        var isUpdated = await _bookingService.UpdateBookingAsync(roomId, id, booking);
        return isUpdated ? Ok() : BadRequest();
    }
}
