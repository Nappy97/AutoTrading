using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Shared.Utilities;
using StackExchange.Redis;

namespace AutoTrading.Infrastructure.Caching;

public class CacheService : ICacheService
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public CacheService(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    public async Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class, new()
    {
        var db = _connectionMultiplexer.GetDatabase();
        var response = await db.StringGetAsync(key);
        return response.IsNullOrEmpty ? NappyJsonSerializer.Deserialize<T>(response!) : new T();
    }

    public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default,
        int expiry = default) where T : class
    {
        var db = _connectionMultiplexer.GetDatabase();
        var serializeValue = NappyJsonSerializer.Serialize(value);
        if (expiry is 0)
            await db.StringSetAsync(key, serializeValue);
        else
            await db.StringSetAsync(key, serializeValue, TimeSpan.FromDays(expiry));
    }

    public async Task<bool> RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return await db.KeyDeleteAsync(key);
    }
}