using Application.DTOs;
using Microsoft.AspNetCore.WebUtilities;
using Web.Client.Models;

namespace Web.Client.Services;

public class RoomService : IRoomService
{
    private readonly HttpClient _httpClient;
    private const string _basePath = "api/rooms/";

    public RoomService(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("hotel");
    }

    public async Task<IEnumerable<RoomModel>> GetAvailableRooms(BookingPeriod period)
    {
        var uri = QueryHelpers.AddQueryString(_basePath + $"available", new Dictionary<string, string?>
        {
            {"checkIn", period.CheckIn.ToShortDateString() },
            {"checkOut", period.CheckOut.ToShortDateString() },
        });
        var rooms = await _httpClient.GetFromJsonAsync<RoomModel[]>(uri);
        return rooms ?? Enumerable.Empty<RoomModel>();
    }

    public async Task<IEnumerable<RoomDto>> GetAllRooms()
    {
        var rooms = await _httpClient.GetFromJsonAsync<RoomDto[]>(_basePath);
        return rooms ?? Enumerable.Empty<RoomDto>();
    }

    public async Task<RoomModel?> GetRoomAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<RoomModel>(_basePath + id);
    }
}
