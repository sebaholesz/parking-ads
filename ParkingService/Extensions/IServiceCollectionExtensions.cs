using Microsoft.OpenApi.Models;
using ParkingService.Application;
using ParkingService.Infrastructure;
using ParkingService.ParkingSpotApi;
using Refit;

namespace ParkingService.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddScoped<ICacheService, CacheService>();
        services.AddScoped<IMapper, Mapper>();
        services.AddScoped<IParkingSpotProvider, ParkingSpotProvider>();

        return services;
    }

    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Parking Service API", Version = "v1" });
        });

        return services;
    }

    public static IServiceCollection ConfigureRefit(
        this IServiceCollection services,
        IConfiguration configurationManager
    )
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configurationManager);

        services.AddRefitClient<IParkingSpotApi>()
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(configurationManager["ParkingSpotApi:BaseAddress"]);
            });

        return services;
    }
}
