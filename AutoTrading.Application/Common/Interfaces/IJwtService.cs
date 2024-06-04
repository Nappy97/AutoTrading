using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Common.Interfaces;

public interface IJwtService
{
    string GenerateAccessToken(User user);
}