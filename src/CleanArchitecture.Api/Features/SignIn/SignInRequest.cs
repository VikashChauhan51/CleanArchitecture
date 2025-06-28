// <copyright file="SignInRequest.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.Api.Features.SignIn;

public record SignInRequest(string UserName, string Password);
