using System.Security.Claims;
using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Users.Commands.CreateUser;
using AutoTrading.Application.Users.Commands.DeleteUser;
using AutoTrading.Application.Users.Commands.UpdateUser.ChangePassword;
using AutoTrading.Application.Users.Commands.UpdateUser.ChangeUserInformation;
using AutoTrading.Shared.Models;
using AutoTrading.Shared.Models.Auth;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = AutoTrading.Shared.Models.Auth.LoginRequest;
using RegisterRequest = AutoTrading.Shared.Models.Auth.RegisterRequest;

namespace AutoTrading.Api.Endpoints;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> LogUserIn(LoginRequest loginRequest)
    {
        var result = await _userService.LoginUserAsync(loginRequest);
        return result.Flag ? Ok(result) : BadRequest(result);
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> RegisterUser(RegisterRequest registerRequest)
    {
        var result = await _userService.RegisterUserAsync(registerRequest);
        return result.Flag ? Ok(result) : BadRequest(result);
    }

    [HttpPost("refresh")]
    public async Task<ActionResult<bool>> RefreshToken(RefreshToken refreshToken)
    {
        var result = await _userService.RequestRefreshToken(refreshToken);
        return Ok(result);
    }

    [HttpPut("modify/password")]
    public async Task<ActionResult<bool>> ModifyPassword(ModifyPasswordRequest modifyPasswordRequest)
    {
        var result = await _userService.ModifyPassword(modifyPasswordRequest);
        return Ok(result);
    }

    //[HttpPost("refresh")]
    //public async Task<ActionResult<>>
}