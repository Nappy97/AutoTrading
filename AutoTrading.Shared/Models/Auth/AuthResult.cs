namespace AutoTrading.Shared.Models.Auth;

public record AuthResult(bool Flag, string JwtToken, string RefreshToken);