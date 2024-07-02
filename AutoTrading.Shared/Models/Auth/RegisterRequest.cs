using System.ComponentModel.DataAnnotations;

namespace AutoTrading.Shared.Models.Auth;

public class RegisterRequest
{
    [Required, MaxLength(50), MinLength(5)]
    public string UserName { get; set; } = string.Empty;

    [Required, MaxLength(50), MinLength(10)]
    public string? Password { get; init; } = string.Empty;

    [Required, Compare(nameof(Password))]
    public string? ConfirmPassword { get; set; } = string.Empty;

    [Required, MaxLength(50), MinLength(2)]
    public string? Name { get; init; }
}