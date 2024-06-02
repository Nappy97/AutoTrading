using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoTrading.Api.Utilities;
using AutoTrading.Application.Users.Queries.Login;
using AutoTrading.Domain.Entities;
using AutoTrading.Shared.Models;
using Microsoft.IdentityModel.Tokens;

namespace AutoTrading.Api.Services;

public class LoginService
{
    private readonly Jwt Jwt;

    public LoginService(Jwt jwt)
    {
        Jwt = jwt;
    }

    public JwtToken CreateJwt(LoginUserQuery loginUser, ISender sender)
    {
        var result = sender.Send(loginUser);
        
        
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName),
            //new(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(Jwt.Key));


        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return new JwtToken(jwt);
    }
}