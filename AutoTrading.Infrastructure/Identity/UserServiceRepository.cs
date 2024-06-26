﻿using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using AutoTrading.Shared.Models.Auth;

namespace AutoTrading.Infrastructure.Identity;

public class UserServiceRepository : IUserService
{
    private readonly IApplicationDbContext _context;
    private readonly IJwtService _jwtService;
    private readonly IIdentityService _identityService;

    public UserServiceRepository(IApplicationDbContext context, IJwtService jwtService, IIdentityService identityService)
    {
        _context = context;
        _jwtService = jwtService;
        _identityService = identityService;
    }
    
    public async Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDto)
    {
        var getUser = await _identityService.GetUserByUserNameAsync(registerUserDto.UserName);

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
        var getUser = await _identityService.GetUserByUserNameAsync(loginDto.UserName!);

        if (getUser is null)
            return new LoginResponse(false, "없는 유저입니다");
        
        // TODO 암호화시 로직 변경
        bool checkPassword = getUser.Password == loginDto.Password;

        if (!checkPassword) 
            return new LoginResponse(false, "비밀번호가 틀립니다.");

        var generateToken = await _jwtService.GenerateAccessTokenAsync(getUser);
        
        var result =  new LoginResponse(true, "성공", generateToken.JwtToken, generateToken.RefreshToken);
        return result;
    }
}