using AutoTrading.Client.Common;
using AutoTrading.Shared.Models.Auth;

namespace AutoTrading.Client.Services.Auth;

public interface IAuthService
{
    Task<RestResult<RegistrationResponse>> Register(RegisterUserDTO request);
    
    Task<RestResult<LoginResponse>> Login(LoginDTO request);
}