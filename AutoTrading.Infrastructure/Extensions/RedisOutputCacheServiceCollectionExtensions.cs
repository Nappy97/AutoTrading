using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Infrastructure.Caching;
using AutoTrading.Infrastructure.Repositories;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Extensions.Options;

namespace AutoTrading.Infrastructure.Extensions;

public static class RedisOutputCacheServiceCollectionExtensions
{
    public static IServiceCollection AddRedisOutputCache(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.RemoveAll<ICacheService>();
        services.AddSingleton<ICacheService, CacheService>();
        
        return services;
    }
    
    public static IServiceCollection AddRedisOutputCache(this IServiceCollection services, Action<OutputCacheOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);

        services.Configure(configureOptions);
        services.AddOutputCache();
        
        services.RemoveAll<IOutputCacheStore>();
        services.AddSingleton<IOutputCacheStore, OutputCacheStore>();

        return services;
    }
}