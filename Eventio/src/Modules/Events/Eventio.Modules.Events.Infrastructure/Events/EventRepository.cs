using Eventio.Modules.Events.Domain.Events;
using Eventio.Modules.Events.Infrastructure.Database;

namespace Eventio.Modules.Events.Infrastructure.Events;

internal sealed class EventRepository(EventsDbContext context): IEventRepository
{
    public void Insert(Event @event)
    {
        context.Events.Add(@event);
    }
}
