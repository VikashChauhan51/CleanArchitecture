// <copyright file="DataProtectionExtensions.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.DataProtection;

namespace CleanArchitecture.SharedKernel;

/// <summary>
/// Provides extension methods for protecting and unprotecting sensitive data using Microsoft Data Protection APIs directly.
/// </summary>
public static class DataProtectionExtensions
{
    /// <summary>
    /// Protects (encrypts) the specified plain text using the provided <see cref="IDataProtector"/>.
    /// </summary>
    /// <param name="plainText">The plain text to protect.</param>
    /// <param name="protector">The data protector instance.</param>
    /// <returns>The protected (encrypted) text.</returns>
    public static string ProtectWith(this string plainText, IDataProtector protector)
        => string.IsNullOrEmpty(plainText) ? plainText : protector.Protect(plainText);

    /// <summary>
    /// Unprotects (decrypts) the specified protected text using the provided <see cref="IDataProtector"/>.
    /// </summary>
    /// <param name="protectedText">The protected (encrypted) text to unprotect.</param>
    /// <param name="protector">The data protector instance.</param>
    /// <returns>The original plain text.</returns>
    public static string UnprotectWith(this string protectedText, IDataProtector protector)
        => string.IsNullOrEmpty(protectedText) ? protectedText : protector.Unprotect(protectedText);
}
