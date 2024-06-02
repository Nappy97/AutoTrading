namespace AutoTrading.Shared.Models;

public class JwtToken
{
    public string? AccessToken { get; set; }

    public JwtToken(string accessToken)
    {
        AccessToken = accessToken;
    }

    public JwtToken()
    {
        
    }
}