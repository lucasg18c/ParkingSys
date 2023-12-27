namespace ParkingSys.API.Extensions;

public static class ParkingSysServices
{
    public static void AddParkingSysServices(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
    }
}
