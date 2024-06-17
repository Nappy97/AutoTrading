namespace AutoTrading.Application.Common.Interfaces;

public interface ICacheService
{
    Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default)
        where T : class, new();

    Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default, int expiry = default)
        where T : class;

    Task<bool> RemoveAsync(string key, CancellationToken cancellationToken = default);

    //Task RemoveByPrefixAsync(string prefixKey, CancellationToken cancellationToken = default);
}