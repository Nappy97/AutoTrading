using AutoTrading.Domain.Entities;
using AutoTrading.Shared.Models.Auth;

namespace AutoTrading.Application.Common.Interfaces;

public interface IJwtService
{
    Task<AuthResult> GenerateAccessTokenAsync(User user);
    Task<string> GenerateRefreshTokenAsync(User user);
}