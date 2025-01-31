using Asp.Versioning;
using CleanArchitecture.Api.Features.SignIn;
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
    private readonly ISender _sender;
    private readonly ILogger<SignUpController> _logger;
    public SignUpController(ISender sender, ILogger<SignUpController> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    [HttpPost(Name = "signUp")]
    [MapToApiVersion(1)]
    public async Task<IActionResult> SignUp(SignUpRequest request)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogDebug("Invalid request");
            return BadRequest(ModelState);
        }
        var outcome = await _sender.Send(request.Adapt<SignUpCommand>());

        return outcome.ToActionResult(this);

    }
}
