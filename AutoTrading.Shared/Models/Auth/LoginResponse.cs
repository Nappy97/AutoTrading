namespace AutoTrading.Shared.Models.Auth;

public record LoginResponse(bool Flag, string Message = null!, string Token = null!, string RefreshToken = null!, DateTime Expired = default!);
