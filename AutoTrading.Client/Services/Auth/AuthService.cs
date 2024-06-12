using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;

namespace AutoTrading.Client.Services.Auth;

public class AuthService : IAuthService
{
    private readonly HttpClient _http;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthService(HttpClient http, AuthenticationStateProvider authenticationStateProvider)
    {
        _http = http;
        _authenticationStateProvider = authenticationStateProvider;
    }
    
    // 회원가입
    public async Task<RegistrationResponse?> Register(RegisterUserDTO request)
    {
        var result = await _http.PostAsJsonAsync("api/user/register", request);
        return await result.Content.ReadFromJsonAsync<RegistrationResponse>();
    }

    public async Task<LoginResponse?> Login(LoginDTO request)
    {
        var result = await _http.PostAsJsonAsync("api/user/login", request);
        return await result.Content.ReadFromJsonAsync<LoginResponse>();
    }
}