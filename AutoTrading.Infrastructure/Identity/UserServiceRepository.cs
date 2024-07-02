using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using AutoTrading.Shared.Models.Auth;

namespace AutoTrading.Infrastructure.Identity;

public class UserServiceRepository : IUserService
{
    private readonly IApplicationDbContext _context;
    private readonly IJwtService _jwtService;
    private readonly IIdentityService _identityService;
    private readonly IUser _user;

    public UserServiceRepository(IApplicationDbContext context, IJwtService jwtService,
        IIdentityService identityService, IUser user)
    {
        _context = context;
        _jwtService = jwtService;
        _identityService = identityService;
        _user = user;
    }

    public async Task<RegistrationResponse> RegisterUserAsync(RegisterRequest registerRequest, CancellationToken cancellationToken = default)
    {
        var getUser = await _identityService.GetUserByUserNameAsync(registerRequest.UserName);

        if (getUser is not null)
            return new RegistrationResponse(false, "존재하는 유저입니다");

        _context.Users.Add(new User
        {
            UserName = registerRequest.UserName,
            Password = registerRequest.Password,
            Name = registerRequest.Name
        });

        await _context.SaveChangesAsync(cancellationToken);
        return new RegistrationResponse(true, "회원가입 완료");
    }

    public async Task<LoginResponse> LoginUserAsync(LoginRequest loginRequest)
    {
        var getUser = await _identityService.GetUserByUserNameAsync(loginRequest.UserName!);

        if (getUser is null)
            return new LoginResponse(false, "없는 유저입니다");

        // TODO 암호화시 로직 변경
        bool checkPassword = getUser.Password == loginRequest.Password;

        if (!checkPassword)
            return new LoginResponse(false, "비밀번호가 틀립니다.");

        var generateToken = await _jwtService.GenerateAccessTokenAsync(getUser);

        var result = new LoginResponse(true, "성공", generateToken.JwtToken, generateToken.RefreshToken);
        return result;
    }

    public async Task<RefreshTokenDto> RequestRefreshToken(RefreshToken oldRefreshToken)
    {
        return null;
    }

    public async Task<bool> ModifyPassword(ModifyPasswordRequest modifyPasswordRequest, CancellationToken cancellationToken = default)
    {
        var user = await _identityService.GetUserBydIdAsync(_user.Id);

        if (user is null)
            return false;

        if (!IsSameAsPasswordAndConfirmPassword(modifyPasswordRequest.NewPassword,
                modifyPasswordRequest.PasswordConfirm))
            return false;

        // TODO 암호화시 로직 변경
        user.Password = modifyPasswordRequest.NewPassword;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    private bool IsSameAsPasswordAndConfirmPassword(string password, string confirmPassword)
    {
        return password == confirmPassword;
    }
}