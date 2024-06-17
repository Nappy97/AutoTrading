using AutoTrading.Shared.Models.Auth;

namespace AutoTrading.Application.Common.Interfaces;

public interface IUserService
{
    Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDto);

    Task<LoginResponse> LoginUserAsync(LoginDTO loginDto);
}