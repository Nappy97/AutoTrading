using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Users.Commands.CreateUser;
using AutoTrading.Application.Users.Commands.UpdateUser.ChangePassword;
using AutoTrading.Application.Users.Queries;
using AutoTrading.Application.Users.Queries.ExistsSameUserName;
using AutoTrading.Application.Users.Queries.GetUserByUserName;
using AutoTrading.Shared.Models.Auth;
using MediatR;

namespace AutoTrading.Core.Services.UserService;

public class UserService : IUserService
{
    private readonly IJwtService _jwtService;
    private readonly IUser _user;
    private readonly ISender _sender;

    public UserService(IJwtService jwtService, IUser user, ISender sender)
    {
        _jwtService = jwtService;
        _user = user;
        _sender = sender;
    }

    /// <summary>
    /// 회원가입
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<RegistrationResponse> RegisterUserAsync(CreateUserCommand command,
        CancellationToken cancellationToken = default)
    {
        // 닉네임 중복 체크
        var hasSameUserName = await _sender.Send(new ExistsSameUserNameQuery
        {
            UserName = command.UserName
        }, cancellationToken);

        if (hasSameUserName)
            return new RegistrationResponse(false, "존재하는 유저입니다");

        var result = await _sender.Send(command, cancellationToken);

        return new RegistrationResponse(result, result ? string.Empty : "실패");
    }

    /// <summary>
    /// 로그인
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    public async Task<LoginResponse> LoginUserAsync(LoginRequest loginRequest)
    {
        var user = await _sender.Send(new GetUserByUserNameQuery
        {
            UserName = loginRequest.UserName
        });

        if (user is null)
            return new LoginResponse(false, "없는 유저입니다");

        // TODO 암호화시 로직 변경
        var checkPassword = user.Password == loginRequest.Password;

        if (!checkPassword)
            return new LoginResponse(false, "비밀번호가 틀립니다.");

        var generateToken = await _jwtService.GenerateAccessTokenAsync(user);

        var result = new LoginResponse(true, "성공", generateToken.JwtToken, generateToken.RefreshToken);
        return result;
    }

    // TODO: 리프레시
    public async Task<RefreshTokenDto> RequestRefreshToken(RefreshToken oldRefreshToken)
    {
        return null;
    }

    /// <summary>
    /// 비밀번호 변경
    /// </summary>
    /// <param name="modifyPasswordRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> ModifyPassword(ModifyPasswordRequest modifyPasswordRequest,
        CancellationToken cancellationToken = default)
    {
        var user = await _sender.Send(new GetUserByUserIdQuery
        {
            UserId = _user.Id
        }, cancellationToken);

        if (user is null)
            return false;

        if (user.Password != modifyPasswordRequest.OldPassword)
            return false;

        // TODO 암호화시 로직 변경
        await _sender.Send(new UpdateUserPasswordCommandQuery(user)
        {
            OldPassword = modifyPasswordRequest.OldPassword,
            NewPassword = modifyPasswordRequest.NewPassword,
            ConfirmNewPassword = modifyPasswordRequest.PasswordConfirm
        }, cancellationToken);

        return true;
    }
}