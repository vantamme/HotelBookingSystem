using Microsoft.EntityFrameworkCore;
using Web.Client.Areas.Identity.Data;
using Web.Client.Data;
using Web.Client.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<WebClientContext>(options =>
                options.UseInMemoryDatabase("HotelClientDb"));
        }
        else
        {
            services.AddDbContext<WebClientContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("WebClientContextConnection")!,
                    builder => builder.MigrationsAssembly(typeof(WebClientContext).Assembly.FullName)));
        }

        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<WebClientContextInitialiser>();

        return services;
    }
}
