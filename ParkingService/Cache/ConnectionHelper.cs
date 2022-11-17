using StackExchange.Redis;
using static ParkingService.ConfigurationManager;

namespace ParkingService.Cache;

public static class ConnectionHelper
{
    static ConnectionHelper()
    {
        LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(AppSetting["Redis:ConnectionString"]));
    }
    
    private static readonly Lazy<ConnectionMultiplexer> LazyConnection;
    
    public static ConnectionMultiplexer Connection => LazyConnection.Value;
}
