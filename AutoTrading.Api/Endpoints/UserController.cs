using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Users.Commands.CreateUser;
using AutoTrading.Application.Users.Commands.DeleteUser;
using AutoTrading.Application.Users.Commands.UpdateUser.ChangePassword;
using AutoTrading.Application.Users.Commands.UpdateUser.ChangeUserInformation;
using AutoTrading.Application.Users.Login;
using AutoTrading.Application.Users.Queries.Login;
using AutoTrading.Application.Users.Register;
using AutoTrading.Shared.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<LoginResponse>> LogUserIn(LoginDTO loginDto)
    {
        var result = await _userService.LoginUserAsync(loginDto);
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> RegisterUser(RegisterUserDTO registerUserDto)
    {
        var result = await _userService.RegisterUserAsync(registerUserDto);
        return Ok(result);
    }
    
    //[HttpPost("refresh")]
    //public async Task<ActionResult<>>
}