using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Common.Interfaces;

public interface IJwtService
{
    Task<string> GenerateAccessTokenAsync(User user);
    Task<bool> GenerateRefreshTokenAsync(User user);
}