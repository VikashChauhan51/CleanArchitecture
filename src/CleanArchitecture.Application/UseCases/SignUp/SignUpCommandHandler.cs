using MediatorForge.Commands;
using ResultifyCore;

namespace CleanArchitecture.Application.UseCases.SignUp;
internal class SignUpCommandHandler : ICommandHandler<SignUpCommand, Outcome<string>>
{
    public Task<Outcome<string>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
