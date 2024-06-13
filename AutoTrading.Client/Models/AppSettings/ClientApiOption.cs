namespace AutoTrading.Client.Models.AppSettings;

public class ClientApiOption
{
    public const string ConfigKey = "ClientApi";

    /// <summary>
    /// Client Api 주소
    /// </summary>
    public string? BaseAddress { get; set; }
}