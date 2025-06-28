// <copyright file="SignInController.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using Asp.Versioning;
using CleanArchitecture.Application.UseCases.SignIn;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResultifyCore.AspNetCore;

namespace CleanArchitecture.Api.Features.SignIn;

[ApiController]
[Route("api/v{version:apiVersion}/signin")]
[ApiVersion(1)]
public class SignInController : ControllerBase
{
    private readonly ISender sender;
    private readonly ILogger<SignInController> logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="SignInController"/> class.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="logger"></param>
    public SignInController(ISender sender, ILogger<SignInController> logger)
    {
        this.sender = sender;
        this.logger = logger;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    [HttpPost(Name = "SignIn")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> SignIn(SignInRequest request)
    {
        if (!this.ModelState.IsValid)
        {
            this.logger.LogDebug("Invalid request");
            return this.BadRequest(this.ModelState);
        }

        var outcome = await this.sender.Send(request.Adapt<SignInCommand>());

        return outcome.ToActionResult(this);
    }
}
