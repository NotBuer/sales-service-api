using SalesService.Domain.Entities.Common;
using SalesService.Domain.Events.Common;

namespace SalesService.Domain.Events;

public class DomainEventHandler() : IDomainEventHandler
{
    public void Handle(List<Entity> domainEventEntities)
    {
        domainEventEntities.ForEach(x =>
        {
            x.DomainEvents.ToList().ForEach(EventDispatch);
            x.ClearEvents();
        });
    }
    
    private static void EventDispatch(DomainEvent domainEvent) =>
        Console.WriteLine($"Event: {domainEvent.GetType().Name} occurred at ${domainEvent.OccurredOn}");
    
}