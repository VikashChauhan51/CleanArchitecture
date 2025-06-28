// <copyright file="ProfileController.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using Asp.Versioning;
using CleanArchitecture.Application.UseCases.Profile;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResultifyCore.AspNetCore;

namespace CleanArchitecture.Api.Features.Profile;

[ApiController]
[Route("api/v{version:apiVersion}/profile/{userId}")]
[ApiVersion(1)]
public class ProfileController : ControllerBase
{
    private readonly ISender sender;
    private readonly ILogger<ProfileController> logger;

    public ProfileController(ISender sender, ILogger<ProfileController> logger)
    {
        this.sender = sender;
        this.logger = logger;
    }

    [HttpGet(Name = "Profile")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Profile([FromRoute] Guid userId)
    {
        if (!this.ModelState.IsValid)
        {
            this.logger.LogDebug("Invalid request");
            return this.BadRequest(this.ModelState);
        }

        var outcome = await this.sender.Send(new ProfileQuery(userId));

        return outcome.ToActionResult(this);
    }
}
