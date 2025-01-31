using MediatorForge.Queries;

namespace CleanArchitecture.Application.UseCases.Profile;
public sealed record ProfileQuery(Guid UserId) : IQuery<Outcome<ProfileResponse>>;
