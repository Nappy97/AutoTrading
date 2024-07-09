using AutoTrading.Core.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace AutoTrading.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}