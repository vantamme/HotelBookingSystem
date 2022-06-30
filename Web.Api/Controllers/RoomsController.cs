using Application;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[Route("api/rooms")]
[ApiController]
public class RoomsController : ControllerBase
{
    private readonly IRoomService _roomService;
    private readonly IMapper _mapper;

    public RoomsController(IRoomService roomService, IMapper mapper)
    {
        _roomService = roomService;
        _mapper = mapper;
    }

    [HttpGet("available")]
    public async Task<IActionResult> Get([FromQuery] BookingPeriod period)
    {
        var rooms = await _roomService.GetAvailableRooms(period);

        var roomsDto = _mapper.Map<IEnumerable<RoomDto>>(rooms);

        return Ok(roomsDto);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var rooms = await _roomService.GetAllRoomsAsync();

        var roomsDto = _mapper.Map<IEnumerable<RoomDto>>(rooms);

        return Ok(roomsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var room = await _roomService.GetRoomAsync(id);

        var roomDto = _mapper.Map<RoomDto>(room);

        return roomDto == null ? NotFound() : Ok(roomDto);
    }
}
