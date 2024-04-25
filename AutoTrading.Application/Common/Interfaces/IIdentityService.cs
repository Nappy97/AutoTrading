using AutoTrading.Application.Common.Models;

namespace AutoTrading.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(long userId);

    Task<bool> IsInRoleAsync(long userId, string role);

    Task<bool> AuthorizeAsync(long userId, string policyName);

    Task<(Result Result, long UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);
}