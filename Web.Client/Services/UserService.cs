using Web.Client.Models;

namespace Web.Client.Services;

public class UserService : IUserService
{
    private readonly HttpClient _client;
    private readonly IHttpContextAccessor _contextAccessor;

    public UserService(IHttpClientFactory factory,
                       IHttpContextAccessor contextAccessor)
    {
        _client = factory.CreateClient("hotel");
        _contextAccessor = contextAccessor;
    }

    public async Task<GuestModel?> GetGuestAsync(Guid id) =>
        await _client.GetFromJsonAsync<GuestModel>($"api/guests/{id}");

    public string GetUsername() => _contextAccessor.HttpContext!.User.Identity!.Name!;
}


