using Asp.Versioning;
using CleanArchitecture.Application.UseCases.SignIn;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Features.SignIn;

[ApiController]
[Route("api/v{version:apiVersion}/")]
[ApiVersion(1)]
public class SignInController : ControllerBase
{
    private readonly ISender _sender;
    private readonly ILogger<SignInController> _logger;
    public SignInController(ISender sender, ILogger<SignInController> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    [HttpPost]
    [Route("signin")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> SignIn(SignInRequest request)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogDebug("Invalid request");
            return BadRequest(ModelState);
        }
        var outcome = await _sender.Send(request.Adapt<SignInCommand>());

        return outcome.MapResponse
        (
            () => Ok(),
            error => BadRequest(error)
        );

    }
}
