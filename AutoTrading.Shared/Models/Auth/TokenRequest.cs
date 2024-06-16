using System.ComponentModel.DataAnnotations;

namespace AutoTrading.Shared.Models.Auth;

public record TokenRequest(
    [Required]
    string Token,
    [Required]
    string RefreshToken);