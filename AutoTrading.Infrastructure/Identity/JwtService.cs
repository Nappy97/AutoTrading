using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using AutoTrading.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AutoTrading.Infrastructure.Identity;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;
    private readonly RedisRepository _redisRepository;
    private readonly IApplicationDbContext _context;

    public JwtService(IConfiguration configuration, RedisRepository redisRepository, IApplicationDbContext context)
    {
        _configuration = configuration;
        _redisRepository = redisRepository;
        _context = context;
    }
    
    public async Task<string> GenerateAccessTokenAsync(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var roles = await _context.UserRoles.Where(x => x.UserId == user.Id).Select(x=> x.RoleId).ToArrayAsync();
        var userClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.Role, string.Join(",", roles))
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

    public async Task<bool> GenerateRefreshTokenAsync(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:RefreshKey"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var userClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName!)
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: userClaims,
            expires: DateTime.Now.AddDays(30),
            signingCredentials: credentials
        );

        var refreshToken = new JwtSecurityTokenHandler().WriteToken(token);
        return await _redisRepository.SetDataAsync(user.Id.ToString(), refreshToken);

    }
}