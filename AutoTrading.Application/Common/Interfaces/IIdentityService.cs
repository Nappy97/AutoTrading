﻿using AutoTrading.Application.Common.Models;
using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetJwtToken(User user);
    
    Task<string?> GetUserNameAsync(long userId);

    Task<bool> IsInRoleAsync(long userId, long roleId);

    Task<bool> AuthorizeAsync(long userId, string policyName);

    Task<(Result Result, long UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);
}