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
    private readonly ISender _sender;
    private readonly ILogger<ProfileController> _logger;
    public ProfileController(ISender sender, ILogger<ProfileController> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    [HttpGet(Name = "Profile")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Profile([FromRoute] Guid userId)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogDebug("Invalid request");
            return BadRequest(ModelState);
        }
        var outcome = await _sender.Send(new ProfileQuery(userId));

        return outcome.ToActionResult(this);

    }
}
