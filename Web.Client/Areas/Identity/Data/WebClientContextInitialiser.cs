using Microsoft.EntityFrameworkCore;
using Web.Client.Data;

namespace Web.Client.Areas.Identity.Data;

public class WebClientContextInitialiser
{
    private readonly ILogger<WebClientContextInitialiser> _logger;
    private readonly WebClientContext _context;

    public WebClientContextInitialiser(ILogger<WebClientContextInitialiser> logger, WebClientContext context)
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
}
