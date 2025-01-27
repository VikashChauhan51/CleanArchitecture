using MediatorForge.Queries;

namespace CleanArchitecture.Application.UseCases.Profile;
public record ProfileQuery(long UserId) : IQuery<ProfileResponse>;
