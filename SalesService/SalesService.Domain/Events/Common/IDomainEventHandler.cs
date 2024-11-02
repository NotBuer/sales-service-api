using SalesService.Domain.Entities.Common;

namespace SalesService.Domain.Events.Common;

public interface IDomainEventHandler
{
    Task HandleAsync(List<Entity> domainEventEntities);
    Task EventDispatchedAsync(DomainEvent domainEvent);
}