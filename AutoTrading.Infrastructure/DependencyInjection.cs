using System.Text;
using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Common.Security;
using AutoTrading.Domain.Constants;
using AutoTrading.Domain.Entities;
using AutoTrading.Infrastructure.Data;
using AutoTrading.Infrastructure.Data.Interceptors;
using AutoTrading.Infrastructure.Extensions;
using AutoTrading.Infrastructure.Identity;
using AutoTrading.Infrastructure.Repositories;
using AutoTrading.Shared.Models;
using Garnet.server;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;

namespace AutoTrading.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        InfrastructureConfigurationModel configuration)
    {
        Guard.Against.Null(configuration.DbConnectionString,
            message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseNpgsql(configuration.DbConnectionString);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitializer>();

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder();

        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IIdentityService, IdentityService>();

        var tokenValidationParameter = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            //ValidIssuer = configuration.JwtIssuer,
            //ValidAudience = configuration.JwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.JwtKey)),
            RequireExpirationTime = true
        };

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = tokenValidationParameter;
        });


        services
            .AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();
        
        services.AddScoped<IJwtService, JwtService>();

        services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(new ConfigurationOptions
        {
            EndPoints = { configuration.RedisConnectionString }
        }));
        services.AddRedisOutputCache();

        // services.AddAuthorizationBuilder()
        //     .AddPolicy(Policies.CanPurge, policy => policy.RequireRole(RoleLevel.Administrator));

        return services;
    }
}