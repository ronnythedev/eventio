using MediatR;
namespace Eventio.Modules.Events.Application.Events;

public sealed class GetEventQuery(Guid EventId) : IRequest<EventResponse?>;

internal sealed class GetEventQueryHandler() : IRequestHandler<GetEventQuery, EventResponse?>
{
    public async Task<EventResponse?> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        
    }
}
public static class GetEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events/{id}", async (Guid id, EventsDbContext context) =>
        {
            EventResponse? @event = await context.Events
                .Where(e => e.Id == id)
                .Select(e => new EventResponse(
                    e.Id,
                    e.Title,
                    e.Description,
                    e.Location,
                    e.StartsAtUtc,
                    e.EndsAtUtc
                ))
                .SingleOrDefaultAsync();

            return @event is null ? Results.NotFound() : Results.Ok(@event);

        }).WithTags(Tags.Events);
    }
    
}
