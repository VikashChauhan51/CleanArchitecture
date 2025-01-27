using MediatorForge.Queries;

namespace CleanArchitecture.Application.UseCases.Profile;
internal class ProfileQueryHandler : IQueryHandler<ProfileQuery, ProfileResponse>
{
    public Task<ProfileResponse> Handle(ProfileQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
