using Newtonsoft.Json;
using ParkingService.Application;
using ParkingService.Cache;
using StackExchange.Redis;

namespace ParkingService.Infrastructure;

public class CacheService : ICacheService
{
    private readonly IDatabase _cache;

    public CacheService()
    {
        this._cache = ConnectionHelper.Connection.GetDatabase();
    }

    public T? GetData<T>(string key)
    {
        RedisValue value = this._cache.StringGet(key);
        return !string.IsNullOrEmpty(value) ? JsonConvert.DeserializeObject<T>(value!) : default;
    }

    public void SetData<T>(string key, T value, DateTimeOffset expirationTime)
    {
        TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
        this._cache.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
    }
}
