// <copyright file="Program.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

await WebApplication.CreateBuilder(args)
    .AddServices()
    .ConfigurePipeline()
    .RunAsync().ConfigureAwait(false);
