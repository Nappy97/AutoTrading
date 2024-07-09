using AutoTrading.Application.Users.Commands.CreateUser;
using AutoTrading.Client.Common;
using AutoTrading.Shared.Models.Auth;

namespace AutoTrading.Client.Services.Auth;

public interface IAuthService
{
    Task<RestResult<RegistrationResponse>> Register(CreateUserCommand request);
    
    Task<RestResult<LoginResponse>> Login(LoginRequest request);
}