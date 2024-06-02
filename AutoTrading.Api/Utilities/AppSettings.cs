namespace AutoTrading.Api.Utilities;

#nullable disable
public class AppSettings
{
    #region singleton

    public static RootObject Instance { get; }

    static AppSettings()
    {
        var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
#if DEBUG
                .AddJsonFile("appsettings.Development.json", true, true)
#endif
            ;

        var config = builder.Build();

        Instance = config.Get<RootObject>();
    }

    #endregion
}

public class RootObject
{
    public Logging Logging { get; set; }
    public string AllowedHosts { get; set; }
    public bool DetailedErrors { get; set; }
    public Garnet Garnet { get; set; }
    public AutoTrading AutoTrading { get; set; }
    public Jwt Jwt { get; set; }
}

public class Logging
{
    public LogLevel LogLevel { get; set; }
}

public class LogLevel
{
    public string Default { get; set; }
}

public class Garnet
{
    public string ConnectionString { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class AutoTrading
{
    public string ConnectionString { get; set; }
}

public class Jwt
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}