using AutoTrading.Application.Users.Commands.CreateUser;
using AutoTrading.Shared.Models.Auth;

namespace AutoTrading.Core.Services.UserService;

public interface IUserService
{
    // 회원가입
    Task<RegistrationResponse> RegisterUserAsync(CreateUserCommand command, CancellationToken cancellationToken = default);

    // 로그인
    Task<LoginResponse> LoginUserAsync(LoginRequest loginRequest);

    // RefreshToken 재발급 TODO
    Task<RefreshTokenDto> RequestRefreshToken(RefreshToken oldRefreshToken);

    Task<bool> ModifyPassword(ModifyPasswordRequest modifyPasswordRequest, CancellationToken cancellationToken = default);
}