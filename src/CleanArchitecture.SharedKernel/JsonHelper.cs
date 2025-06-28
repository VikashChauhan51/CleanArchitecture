// <copyright file="JsonHelper.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using System.Text.Json;
using System.Text.Json.Serialization;

namespace CleanArchitecture.SharedKernel;

/// <summary>
/// Provides helper methods for JSON serialization and deserialization using System.Text.Json.
/// </summary>
public static class JsonHelper
{
    private static readonly JsonSerializerOptions DefaultOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    /// <summary>
    /// Serializes an object to a JSON string using the specified or default options.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="obj">The object to serialize.</param>
    /// <param name="options">Optional JSON serializer options.</param>
    /// <returns>The JSON string representation of the object.</returns>
    public static string Serialize<T>(T obj, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Serialize(obj, options ?? DefaultOptions);
    }

    /// <summary>
    /// Deserializes a JSON string to an object of type <typeparamref name="T"/> using the specified or default options.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
    /// <param name="json">The JSON string to deserialize.</param>
    /// <param name="options">Optional JSON serializer options.</param>
    /// <returns>The deserialized object, or null if deserialization fails.</returns>
    public static T? Deserialize<T>(string json, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Deserialize<T>(json, options ?? DefaultOptions);
    }

    /// <summary>
    /// Gets the default <see cref="JsonSerializerOptions"/> used by the helper.
    /// </summary>
    /// <returns>The default <see cref="JsonSerializerOptions"/> instance.</returns>
    public static JsonSerializerOptions GetDefaultOptions()
    {
        return DefaultOptions;
    }
}
