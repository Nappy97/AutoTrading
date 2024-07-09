using AutoTrading.Application.Users.Commands.CreateUser;
using AutoTrading.Core.Services.UserService;
using AutoTrading.Shared.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = AutoTrading.Shared.Models.Auth.LoginRequest;

namespace AutoTrading.Api.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(Login, "login")
            .MapPost(RegisterUser, "register")
            .MapPost(RefreshToken, "refresh")
            .MapPut(ModifyPassword, string.Empty);
    }

    private async Task<LoginResponse> Login([FromBody] LoginRequest loginRequest,
        [FromServices] IUserService userService)
    {
        return await userService.LoginUserAsync(loginRequest);
    }

    private async Task<RegistrationResponse> RegisterUser([FromBody] CreateUserCommand command,
        [FromServices] IUserService userService)
    {
        return await userService.RegisterUserAsync(command);
    }

    private async Task<RefreshTokenDto> RefreshToken([FromBody] RefreshToken refreshToken,
        [FromServices] IUserService userService)
    {
        return await userService.RequestRefreshToken(refreshToken);
    }

    private async Task<bool> ModifyPassword([FromBody] ModifyPasswordRequest command,
        [FromServices] IUserService userService)
    {
        return await userService.ModifyPassword(command);
    }
}