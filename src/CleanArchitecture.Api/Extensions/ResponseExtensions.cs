using Microsoft.AspNetCore.Mvc;
using ResultifyCore;

namespace CleanArchitecture.Api.Extensions;

public static class ResponseExtensions
{

    public static IActionResult MapResponse(this Outcome outcome,
        Func<IActionResult> onSuccess,
        Func<IEnumerable<OutcomeError>, IActionResult> onError)
    {
        if (outcome.IsSuccess)
        {
            return onSuccess();
        }
        else
        {
            return onError(outcome.Errors);
        }
    }
    public static IActionResult MapResponse<TResponse>(this Outcome<TResponse> outcome,
        Func<TResponse?, IActionResult> onSuccess,
        Func<IEnumerable<OutcomeError>, IActionResult> onError)
    {
        if (outcome.IsSuccess)
        {
            return onSuccess(outcome.Value);
        }
        else
        {
            return onError(outcome.Errors);
        }
    }
}
