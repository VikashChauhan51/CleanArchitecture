// <copyright file="ErrorHandlerMiddleware.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace CleanArchitecture.Api.Middlewares;

/// <summary>
/// Middleware for handling exceptions and returning standardized error responses.
/// </summary>
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ErrorHandlerMiddleware> logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorHandlerMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <param name="logger">The logger instance for logging errors.</param>
    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    /// <summary>
    /// Invokes the middleware to handle exceptions that occur during request processing.
    /// </summary>
    /// <param name="context">The HTTP context for the current request.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await this.next(context).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            await this.HandleExceptionAsync(context, ex).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Handles exceptions by logging them and writing a standardized error response.
    /// </summary>
    /// <param name="context">The HTTP context for the current request.</param>
    /// <param name="exception">The exception that was thrown.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        this.logger.LogError(exception, "An unhandled exception has occurred");

        var statusCode = exception switch
        {
            ValidationException => StatusCodes.Status400BadRequest,
            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError,
        };

        context.Response.StatusCode = statusCode;

        var problemDetails = new HttpValidationProblemDetails
        {
            Status = statusCode,
            Title = statusCode switch
            {
                StatusCodes.Status400BadRequest => "Validation Error",
                StatusCodes.Status403Forbidden => "Access Denied",
                StatusCodes.Status401Unauthorized => "Unauthorized",
                StatusCodes.Status429TooManyRequests => "Too Many Requests",
                _ => "Internal Server Error",
            },
            Detail = exception.Message,
            Instance = context.Request.Path,
            Type = statusCode switch
            {
                StatusCodes.Status400BadRequest => "https://httpstatuses.com/400",
                StatusCodes.Status403Forbidden => "https://httpstatuses.com/403",
                StatusCodes.Status401Unauthorized => "https://httpstatuses.com/401",
                StatusCodes.Status429TooManyRequests => "https://httpstatuses.com/429",
                _ => "https://httpstatuses.com/500",
            },
        };

        if (exception is ValidationException validation)
        {
            Dictionary<string, string[]>? dictionary = validation.Errors?
                            .GroupBy(x => x.PropertyName, StringComparer.Ordinal)
                            .ToDictionary(
                                g => g.Key,
                                g => g.Select(e => e.ErrorMessage).ToArray(),
                                StringComparer.Ordinal);
            if (dictionary != null)
            {
                problemDetails.Errors = dictionary;
            }
        }

        await context.Response.WriteAsJsonAsync(
            problemDetails,
            options: new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            },
            contentType: MediaTypeNames.Application.ProblemJson).ConfigureAwait(false);
    }
}
