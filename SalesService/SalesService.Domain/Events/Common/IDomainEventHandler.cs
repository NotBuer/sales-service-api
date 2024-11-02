using SalesService.Domain.Entities.Common;

namespace SalesService.Domain.Events.Common;

public interface IDomainEventHandler
{
    void Handle(List<Entity> domainEventEntities);
}