using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Parkings.Infrastructure;


public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configure the database for the application
    /// </summary>
    /// <param name="services">This application's serives</param>
    /// <param name="configuration">This application's configuration</param>
    /// <returns>Services with the database setup</returns>
    public static IServiceCollection AddParkingDbContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ParkingsDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Default"));
        });

        return services;
    }
}
