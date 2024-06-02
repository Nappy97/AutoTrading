using AutoTrading.Shared.Models;

namespace AutoTrading.Application.Users.Queries.Login;

public class LoginResultDto
{
    public bool Success { get; set; } = true;
    public string? Message { get; set; } = string.Empty;
    public JwtToken JwtToken { get; set; } = new();
}