using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IAppDbContext
{
    DbSet<Guest> Guests { get; }
    DbSet<Room> Rooms { get; }
    DbSet<Booking> Bookings { get; }
    Task<int> SaveChangesAsync();
}
