// <copyright file="SignUpRequest.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.Api.Features.SignUp;

public record SignUpRequest(string FullName, string UserName, string Password);
