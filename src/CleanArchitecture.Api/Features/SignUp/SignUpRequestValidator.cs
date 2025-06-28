// <copyright file="SignUpRequestValidator.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.Api.Features.SignUp;

public sealed class SignUpRequestValidator : AbstractValidator<SignUpRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SignUpRequestValidator"/> class.
    /// </summary>
    public SignUpRequestValidator()
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
