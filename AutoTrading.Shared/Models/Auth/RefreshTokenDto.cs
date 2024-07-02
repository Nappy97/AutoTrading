namespace AutoTrading.Shared.Models.Auth;

public record RefreshTokenDto(string TokenType, string AccessToken, int ExpiresIn, string RefreshToken);