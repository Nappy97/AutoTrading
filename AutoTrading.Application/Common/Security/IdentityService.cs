using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Common.Models;
using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Common.Security;

public class IdentityService : IIdentityService
{
    private readonly string? JwtToken;

    public IdentityService(Jwt jwtToken)
    {
        JwtToken = jwtToken;
    }
    
    public Task<string?> GetJwtToken(User user)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetUserNameAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsInRoleAsync(long userId, long roleId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AuthorizeAsync(long userId, string policyName)
    {
        throw new NotImplementedException();
    }

    public Task<(Result Result, long UserId)> CreateUserAsync(string userName, string password)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteUserAsync(string userId)
    {
        throw new NotImplementedException();
    }
}



