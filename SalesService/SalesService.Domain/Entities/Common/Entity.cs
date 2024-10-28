namespace SalesService.Domain.Entities.Common;

public abstract class Entity
{
    private List<DomainEvent> _domainEvents = [];
    public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void RaiseEvent(DomainEvent domainEvent) =>
        _domainEvents.Add(domainEvent);
    
    protected void ClearEvents() => _domainEvents.Clear();
}