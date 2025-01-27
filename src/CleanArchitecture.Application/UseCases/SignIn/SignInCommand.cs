using MediatorForge.Commands;
using ResultifyCore;

namespace CleanArchitecture.Application.UseCases.SignIn;
public record SignInCommand
(
    string UserName,
    string Password
) : ICommand<Outcome>;
