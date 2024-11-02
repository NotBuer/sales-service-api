using SalesService.Domain.Events.Common;

namespace SalesService.Domain.Entities.Common;

public abstract class Entity
{
    private List<DomainEvent> _domainEvents = [];
    public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected internal void RaiseEvent(DomainEvent domainEvent) =>
        _domainEvents.Add(domainEvent);
    
    protected internal void ClearEvents() => _domainEvents.Clear();
}