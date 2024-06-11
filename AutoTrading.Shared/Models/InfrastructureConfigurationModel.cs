namespace AutoTrading.Shared.Models;

public class InfrastructureConfigurationModel
{
    public required string DbConnectionString { get; set; }
    public required string JwtIssuer { get; set; }
    public required string JwtAudience { get; set; }
    public required string JwtKey { get; set; }
    public required string RefreshKey { get; set; }
}