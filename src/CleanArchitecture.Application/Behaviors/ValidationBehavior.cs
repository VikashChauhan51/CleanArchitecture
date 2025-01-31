using MediatorForge.Behaviors;

namespace CleanArchitecture.Application.Behaviors;


public class ValidationBehavior<TRequest, TResponse> : IBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : notnull
{
    private readonly IEnumerable<IValidator<TRequest>>? _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>>? validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators != null)
        {
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(request, cancellationToken)));
            var failures = validationResults.SelectMany(result => result.Errors).Where(f => f != null).ToList();

            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
        }

        return await next();
    }
}

