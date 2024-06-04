using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Users.Login;
using AutoTrading.Application.Users.Register;
using AutoTrading.Domain.Entities;
using AutoTrading.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AutoTrading.Infrastructure.Identity;

public class UserServiceRepository : IUserService
{
    private readonly IApplicationDbContext _context;
    private readonly IJwtService _jwtService;

    public UserServiceRepository(IApplicationDbContext context, IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
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
            return new LoginResponse(true, "성공", _jwtService.GenerateAccessToken(getUser));
        else
            return new LoginResponse(false, "비밀번호가 틀립니다.");
    }

    

    private RefreshToken GenerateRefreshToken()
    {
        var refreshToken = new RefreshToken
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expires = DateTime.Now.AddDays(7)
        };

        return refreshToken;
    }

    /*private void SetRefreshToken(RefreshToken newRefreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = newRefreshToken.Expires,
        };
        
        Response
    }*/

    private async Task<User> FindUserByUserName (string userName) =>
        await _context.Users
            .Include(u => u.UserRoles)
            .FirstOrDefaultAsync(u => u.UserName == userName);
}