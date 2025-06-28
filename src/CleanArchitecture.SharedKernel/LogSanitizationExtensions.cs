// <copyright file="LogSanitizationExtensions.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.SharedKernel;

/// <summary>
/// Provides extension methods for sanitizing and masking sensitive data in log strings.
/// </summary>
public static class LogSanitizationExtensions
{

    /// <summary>
    /// Sanitizes a dictionary of log parameters by masking sensitive values and ignoring control keys.
    /// </summary>
    /// <param name="input">The log parameters to sanitize.</param>
    /// <returns>A new dictionary with sensitive values masked and control keys untouched.</returns>
    public static string SanitizeForLog(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        // Remove control characters from the input string
        return new string([.. input.Where(c => !char.IsControl(c))]);
    }

    /// <summary>
    /// Masks a sensitive value for logging.
    /// </summary>
    /// <param name="value">The value to mask.</param>
    /// <returns>The masked value.</returns>
    public static string MaskValue(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        bool hide = true;

        char[] valueArray = value.ToCharArray();
        for (int i = 0; i < value.Length; i++)
        {
            if ((i + 1) % 3 == 0)
            {
                hide = !hide;
            }

            if (hide)
            {
                valueArray[i] = '*';
            }
        }

        return new string(valueArray);
    }
}
