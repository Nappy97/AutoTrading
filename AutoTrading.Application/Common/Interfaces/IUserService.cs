using AutoTrading.Shared.Models.Auth;

namespace AutoTrading.Application.Common.Interfaces;

public interface IUserService
{
    Task<RegistrationResponse> RegisterUserAsync(RegisterRequest registerRequest, CancellationToken cancellationToken = default);

    Task<LoginResponse> LoginUserAsync(LoginRequest loginRequest);

    Task<RefreshTokenDto> RequestRefreshToken(RefreshToken oldRefreshToken);

    Task<bool> ModifyPassword(ModifyPasswordRequest modifyPasswordRequest, CancellationToken cancellationToken = default);
}