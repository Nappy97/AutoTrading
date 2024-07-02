using AutoTrading.Application.Common.Models;
using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(long userId);

    Task<User?> GetUserBydIdAsync(long userId);

    Task<User?> GetUserByUserNameAsync(string userName);

    Task<bool> IsInRoleAsync(long userId, long roleId);

    Task<bool> AuthorizeAsync(long userId, string policyName);

    Task<(Result Result, long UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);
}