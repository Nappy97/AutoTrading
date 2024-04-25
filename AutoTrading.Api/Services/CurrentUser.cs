﻿using System.Security.Claims;
using AutoTrading.Domain.Entities;

namespace AutoTrading.Api.Services;

public class CurrentUser : User
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    // public long Id => _httpContextAccessor.HttpContext?.User?.FindFirstValue();
    public long Id => long.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
}