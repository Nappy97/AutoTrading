using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using AutoTrading.Infrastructure.Caching;
using AutoTrading.Infrastructure.Repositories;
using AutoTrading.Shared.Extensions;
using AutoTrading.Shared.Models.Auth;
using AutoTrading.Shared.Utilities;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AutoTrading.Infrastructure.Identity;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;
    private readonly ICacheService _cacheService;
    private readonly IApplicationDbContext _context;

    public JwtService(IConfiguration configuration, ICacheService cacheService, IApplicationDbContext context)
    {
        _configuration = configuration;
        _cacheService = cacheService;
        _context = context;
    }

    public async Task<AuthResult> GenerateAccessTokenAsync(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var roles = await _context.UserRoles.Where(x => x.UserId == user.Id).Select(x => x.RoleId).ToArrayAsync();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                //new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Role, string.Join(",", roles)),
                new Claim(JwtRegisteredClaimNames.Iat,
                    DateTime.Now.ToUniversalTime().ToString(NappyCultureInfo.Default.DateTimeFormat))
            }),
            Expires = DateTime.Now.AddDays(1),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = credentials
        };
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);;
        var jwtToken = jwtSecurityTokenHandler.WriteToken(token);
        var refreshToken = await GenerateRefreshTokenAsync(user.Id, jwtToken);
        return new AuthResult(true, jwtToken, refreshToken);
    }

    private async Task<string> GenerateRefreshTokenAsync(long userId, string jwtToken)
    {
        var refreshToken = jwtToken.Sha256Hash();
        await _cacheService.SetAsync(userId.ToString(), refreshToken);
        return refreshToken;
    }
}