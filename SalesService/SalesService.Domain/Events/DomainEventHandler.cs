using SalesService.Domain.Entities.Common;
using SalesService.Domain.Events.Common;

namespace SalesService.Domain.Events;

public class DomainEventHandler() : IDomainEventHandler
{
    public async Task HandleAsync(List<Entity> domainEventEntities)
    {
        await Task.WhenAll(
            domainEventEntities.SelectMany(x =>
            {
                var tasks = x.DomainEvents.Select(EventDispatchedAsync);
                x.ClearEvents();
                return tasks;
            })
        );
    }

    public async Task EventDispatchedAsync(DomainEvent domainEvent)
    {
        Console.WriteLine($"Domain Event: {domainEvent.GetType().Name} occurred");
        await Task.Delay(50);
    }
}