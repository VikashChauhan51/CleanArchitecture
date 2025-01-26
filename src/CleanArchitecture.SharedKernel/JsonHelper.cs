using System.Text.Json;
using System.Text.Json.Serialization;

namespace CleanArchitecture.SharedKernel;

public static class JsonHelper
{
    private static readonly JsonSerializerOptions _defaultOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public static string Serialize<T>(T obj, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Serialize(obj, options ?? _defaultOptions);
    }

    public static T? Deserialize<T>(string json, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Deserialize<T>(json, options ?? _defaultOptions);
    }

    public static JsonSerializerOptions GetDefaultOptions() => _defaultOptions;
}

