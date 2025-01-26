﻿using MediatorForge.Behaviors;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Behaviors;


public class LoggingBehavior<TRequest, TResponse> : IBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : notnull
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Handling {typeof(TRequest).Name}");

        var response = await next();

        _logger.LogInformation($"Handled {typeof(TResponse).Name}");

        return response;
    }
}

