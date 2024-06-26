namespace AutoTrading.Shared.Extensions;

public static class LongExtensions
{
    public static Dictionary<string, object> ToQueryParameters(this long data, string fieldName)
    {
        return new Dictionary<string, object> { { nameof(data), fieldName } };
    }
}