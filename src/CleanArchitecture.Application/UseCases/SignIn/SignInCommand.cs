using MediatorForge.Commands;
using ResultifyCore;

namespace CleanArchitecture.Application.UseCases.SignIn;
public sealed record SignInCommand
(
    string UserName,
    string Password
) : ICommand<Outcome<string>>;
