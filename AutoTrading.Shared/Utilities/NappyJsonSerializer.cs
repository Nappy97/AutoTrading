using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace AutoTrading.Shared.Utilities;

public static class NappyJsonSerializer
{
    public static readonly JsonSerializerOptions DefaultSerializerOptions = new()
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
        PropertyNameCaseInsensitive = true,
        ReferenceHandler = ReferenceHandler.IgnoreCycles
    };

    public static string Serialize<T>(T value, JsonSerializerOptions? options = null)
    {
        options ??= DefaultSerializerOptions;

        return JsonSerializer.Serialize(value, options);
    }

    public static T Deserialize<T>(string value, JsonSerializerOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(value))
            return default!;

        options ??= DefaultSerializerOptions;

        return JsonSerializer.Deserialize<T>(value, options) ?? default!;
    }
}