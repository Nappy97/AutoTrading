using System.Security.Claims;
using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using Microsoft.AspNetCore.Authentication;

namespace AutoTrading.Api.Services;

public class CurrentUserService : IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public bool HasAuthenticated =>
        _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier) != null;

    public long Id => long.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    public string Name => _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Name)!;

    public long[] Roles => _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Role)!.Split(",")
        .Select(long.Parse).ToArray();

    public long[] Actions => _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.System)!.Split(",")
        .Select(long.Parse).ToArray();
}