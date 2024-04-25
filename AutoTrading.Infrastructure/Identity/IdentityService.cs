// using AutoTrading.Application.Common.Interfaces;
// using AutoTrading.Application.Common.Models;
// using AutoTrading.Domain.Entities;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Identity;
//
// namespace AutoTrading.Infrastructure.Identity;
//
// public class IdentityService : IIdentityService
// {
//     private readonly UserManager<User> _userManager;
//     private readonly IUserClaimsPrincipalFactory<User> _userClaimsPrincipalFactory;
//     private readonly IAuthorizationService _authorizationService;
//
//     public IdentityService(UserManager<User> userManager, IUserClaimsPrincipalFactory<User> userClaimsPrincipalFactory,
//         IAuthorizationService authorizationService)
//     {
//         _userManager = userManager;
//         _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
//         _authorizationService = authorizationService;
//     }
//
//     public Task<string?> GetUserNameAsync(long userId)
//     {
//         var user = await _userManager.FindByIdAsync(userId);
//     }
//
//     public Task<bool> IsInRoleAsync(long userId, string role)
//     {
//         throw new NotImplementedException();
//     }
//
//     public Task<bool> AuthorizeAsync(long userId, string policyName)
//     {
//         throw new NotImplementedException();
//     }
//
//     public Task<(Result Result, long UserId)> CreateUserAsync(string userName, string password)
//     {
//         throw new NotImplementedException();
//     }
//
//     public Task<Result> DeleteUserAsync(string userId)
//     {
//         throw new NotImplementedException();
//     }
// }