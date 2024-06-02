namespace AutoTrading.Application.Users.Login;

public record LoginResponse(bool Flag, string Message = null!, string Token = null!);
