using System.Net.Http.Json;
using AutoTrading.Client.Common;
using AutoTrading.Shared.Models.Auth;
using Microsoft.AspNetCore.Components.Authorization;

namespace AutoTrading.Client.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IRestClient _client;

    public AuthService(IRestClient client)
    {
        _client = client;
    }

    // 회원가입
    public async Task<RestResult<RegistrationResponse>> Register(RegisterRequest request)
    {
        return await _client.PostAsync<RegisterRequest, RegistrationResponse>("api/user/register", request);
    }

    // 로그인
    public async Task<RestResult<LoginResponse>> Login(LoginRequest request)
    {
        return await _client.PostAsync<LoginRequest, LoginResponse>("api/user/login", request);
    }
}