using StackExchange.Redis;

namespace AutoTrading.Infrastructure.Repositories;

public class RedisRepository
{
    private readonly IDatabase _database;

    public RedisRepository(IConnectionMultiplexer redis)
    {
        _database = redis.GetDatabase();
    }

    public async Task<bool> SetDataAsync(string key, string value)
    {
        return await _database.StringSetAsync(key, value);
    }

    public async Task<string> GetDataAsync(string key, string value)
    {
        var result = await _database.StringGetAsync(key);
        return result == default ? string.Empty : result;
    }
}