namespace CleanArchitecture.Application.UseCases.SignUp;

public sealed class SignUpCommandValidator : AbstractValidator<SignUpCommand>
{
    public SignUpCommandValidator()
    {
        RuleFor(x => x.FullName)
        .NotNull()
        .NotEmpty()
        .MaximumLength(100);

        RuleFor(x => x.UserName)
        .NotNull()
        .NotEmpty()
        .MaximumLength(100);

        RuleFor(x => x.Password)
       .NotNull()
       .NotEmpty()
       .MaximumLength(100);
    }
}
