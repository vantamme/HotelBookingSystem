using Application.DTOs;

namespace Application.Interfaces;

public interface IRoomService
{
    Task<IEnumerable<RoomDto>> GetAllRoomsAsync();
    Task<IEnumerable<RoomDto>> GetAvailableRooms(BookingPeriod period);
    Task<RoomDto?> GetRoomAsync(Guid roomId);
}