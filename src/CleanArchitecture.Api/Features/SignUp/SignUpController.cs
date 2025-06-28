// <copyright file="SignUpController.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using Asp.Versioning;
using CleanArchitecture.Application.UseCases.SignUp;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResultifyCore.AspNetCore;

namespace CleanArchitecture.Api.Features.SignUp;

[ApiController]
[Route("api/v{version:apiVersion}/signup")]
[ApiVersion(1)]
public class SignUpController : ControllerBase
{
    private readonly ISender sender;
    private readonly ILogger<SignUpController> logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="SignUpController"/> class.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="logger"></param>
    public SignUpController(ISender sender, ILogger<SignUpController> logger)
    {
        this.sender = sender;
        this.logger = logger;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    [HttpPost(Name = "signUp")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> SignUp(SignUpRequest request)
    {
        if (!this.ModelState.IsValid)
        {
            this.logger.LogDebug("Invalid request");
            return this.BadRequest(this.ModelState);
        }

        var outcome = await this.sender.Send(request.Adapt<SignUpCommand>());

        return outcome.ToActionResult(this);
    }
}
