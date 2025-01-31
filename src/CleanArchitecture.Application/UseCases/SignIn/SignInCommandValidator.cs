namespace CleanArchitecture.Application.UseCases.SignIn;
public sealed class SignInCommandValidator : AbstractValidator<SignInCommand>
{
    public SignInCommandValidator()
    {
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
