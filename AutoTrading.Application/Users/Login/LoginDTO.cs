using System.ComponentModel.DataAnnotations;

namespace AutoTrading.Application.Users.Login;

public class LoginDTO
{
    [Required]
    public string? UserName { get; set; } = string.Empty;

    [Required]
    public string? Password { get; set; } = string.Empty;
}