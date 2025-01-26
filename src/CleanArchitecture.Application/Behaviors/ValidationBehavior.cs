using System;
using FluentValidation;
using MediatorForge.Behaviors;
using MediatR;

namespace CleanArchitecture.Application.Behaviors;


public class ValidationBehavior<TRequest, TResponse> : IBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : notnull
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator != null)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        return await next();
    }
}

