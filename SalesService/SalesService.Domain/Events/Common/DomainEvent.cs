namespace SalesService.Domain.Events.Common;

public interface IDomainEvent
{
    public DateTime OccurredOn { get; init; }
}

public abstract record DomainEvent : IDomainEvent
{
    public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
}