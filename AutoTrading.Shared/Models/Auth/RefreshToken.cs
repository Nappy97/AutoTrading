namespace AutoTrading.Shared.Models.Auth;

public record RefreshToken(string Token, string JwtId, DateTime ExpiryDate);
