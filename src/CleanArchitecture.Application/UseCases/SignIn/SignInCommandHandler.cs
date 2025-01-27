using MediatorForge.Commands;
using ResultifyCore;

namespace CleanArchitecture.Application.UseCases.SignIn;
internal class SignInCommandHandler : ICommandHandler<SignInCommand, Outcome>
{
    public Task<Outcome> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
