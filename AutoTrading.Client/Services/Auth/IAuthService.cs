namespace AutoTrading.Client.Services.Auth;

public interface IAuthService
{
    Task<RegistrationResponse?> Register(RegisterUserDTO request);
    
    Task<LoginResponse?> Login(LoginDTO request);
}