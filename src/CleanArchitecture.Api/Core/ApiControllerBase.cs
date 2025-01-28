using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ResultifyCore;

namespace CleanArchitecture.Api.Core;

[Controller]
public abstract class ApiControllerBase : ControllerBase
{
    public virtual IActionResult MapErrors(OutcomeStatus status, IEnumerable<OutcomeError> errors)
    {
        return status switch
        {
            OutcomeStatus.Failure => StatusCode(StatusCodes.Status500InternalServerError, errors),
            OutcomeStatus.Validation => BadRequest(errors),
            OutcomeStatus.Problem => StatusCode(
                StatusCodes.Status500InternalServerError,
                new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "A problem occurred",
                    Detail = string.Join("; ", errors)
                }),
            OutcomeStatus.NotFound => NotFound(errors),
            OutcomeStatus.Conflict => Conflict(errors),
            OutcomeStatus.Unauthorized => Forbid(),
            _ => Ok()
        };

    }
}
