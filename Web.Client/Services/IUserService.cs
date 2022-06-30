using Web.Client.Models;

namespace Web.Client.Services;

public interface IUserService
{
    Task<GuestModel?> GetGuestAsync(Guid id);
    string GetUsername();
}