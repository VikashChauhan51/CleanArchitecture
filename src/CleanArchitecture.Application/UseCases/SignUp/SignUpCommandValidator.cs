// <copyright file="SignUpCommandValidator.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.Application.UseCases.SignUp;

public sealed class SignUpCommandValidator : AbstractValidator<SignUpCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SignUpCommandValidator"/> class.
    /// </summary>
    public SignUpCommandValidator()
    {
        this.RuleFor(x => x.FullName)
        .NotNull()
        .NotEmpty()
        .MaximumLength(100);

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
