using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Persistence;

public class AppDbContextInitialiser
{
    private readonly ILogger<AppDbContextInitialiser> _logger;
    private readonly AppDbContext _context;

    public AppDbContextInitialiser(ILogger<AppDbContextInitialiser> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        if (!_context.Rooms.Any())
        {
            _context.Rooms.Add(new Room { RoomNr = 1, Capacity = 1, Price = 50 });
            _context.Rooms.Add(new Room { RoomNr = 2, Capacity = 2, Price = 75 });
            _context.Rooms.Add(new Room { RoomNr = 3, Capacity = 3, Price = 100 });

            await _context.SaveChangesAsync();
        }
    }
}
