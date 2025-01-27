using CleanArchitecture.Domain.Core;


namespace CleanArchitecture.Domain.Events;
public sealed record class SignUpEvent(long UserId) : DomainEvent;

