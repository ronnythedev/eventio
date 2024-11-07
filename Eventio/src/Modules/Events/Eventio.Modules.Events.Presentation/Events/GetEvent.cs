using Eventio.Modules.Events.Application.Events;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
namespace Eventio.Modules.Events.Presentation.Events;

internal static class GetEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events/{id}", async (Guid id, ISender sender) =>
        {
            EventResponse @event = await sender.Send(new GetEventQuery(id));
            
            return @event is null ? Results.NotFound() : Results.Ok(@event);

        }).WithTags(Tags.Events);
    }
    
}
