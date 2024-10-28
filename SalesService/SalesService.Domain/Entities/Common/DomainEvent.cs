namespace SalesService.Domain.Entities.Common;

public interface IDomainEvent
{
    public DateTime OccurredOn { get; init; }
}

public abstract record DomainEvent : IDomainEvent
{
    public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
}