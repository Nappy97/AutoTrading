using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Users.Login;
using AutoTrading.Application.Users.Register;
using AutoTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AutoTrading.Infrastructure.Identity;

public class UserRepository : IUser
{
    private readonly IApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public UserRepository(IApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    
    public async Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDto)
    {
        var getUser = await FindUserByUserName(registerUserDto.UserName);

        if (getUser is not null)
            return new RegistrationResponse(false, "존재하는 유저입니다");

        _context.Users.Add(new User
        {
            UserName = registerUserDto.UserName,
            Password = registerUserDto.Password,
            Name = registerUserDto.Name
        });

        await _context.SaveChangesAsync(CancellationToken.None);
        return new RegistrationResponse(true, "회원가입 완료");
    }

    public async Task<LoginResponse> LoginUserAsync(LoginDTO loginDto)
    {
        var getUser = await FindUserByUserName(loginDto.UserName!);

        if (getUser is null)
            return new LoginResponse(false, "없는 유저입니다");
        
        // TODO 암호화시 로직 변경
        bool checkPassword = getUser.Password == loginDto.Password;

        if (checkPassword)
            return new LoginResponse(true, "성공", GenerateJWTToken(getUser));
        else
            return new LoginResponse(false, "비밀번호가 틀립니다.");
    }

    private string GenerateJWTToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var userClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName!)
            // 권한 role
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: userClaims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task<User> FindUserByUserName (string userName) =>
        await _context.Users
            .FirstOrDefaultAsync(u => u.UserName == userName);
}