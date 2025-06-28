// <copyright file="SignInCommandValidator.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.Application.UseCases.SignIn;

public sealed class SignInCommandValidator : AbstractValidator<SignInCommand>
{
    public SignInCommandValidator()
    {
        this.RuleFor(x => x.UserName)
        .NotNull()
        .NotEmpty()
        .MaximumLength(100);

        this.RuleFor(x => x.Password)
       .NotNull()
       .NotEmpty()
       .MaximumLength(100);
    }
}
