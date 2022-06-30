using Application.DTOs;
using Web.Client.Models;

namespace Web.Client.Services;

public interface IRoomService
{
    Task<IEnumerable<RoomModel>> GetAvailableRooms(BookingPeriod period);
    Task<RoomModel?> GetRoomAsync(Guid id);
    Task<IEnumerable<RoomDto>> GetAllRooms();
}