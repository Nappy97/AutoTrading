using AutoTrading.Application.Users.Login;
using AutoTrading.Application.Users.Register;

namespace AutoTrading.Application.Common.Interfaces;

public interface IUserService
{
    Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDto);

    Task<LoginResponse> LoginUserAsync(LoginDTO loginDto);
}