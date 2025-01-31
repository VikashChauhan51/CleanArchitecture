using MediatorForge.Commands;
using ResultifyCore;

namespace CleanArchitecture.Application.UseCases.SignUp;
public sealed record SignUpCommand
(
    string FullName,
    string UserName,
    string Password
) : ICommand<Outcome<string>>;
