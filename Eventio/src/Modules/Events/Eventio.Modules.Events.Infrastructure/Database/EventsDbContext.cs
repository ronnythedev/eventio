using Eventio.Modules.Events.Application.Abstractions.Data;
using Eventio.Modules.Events.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace Eventio.Modules.Events.Infrastructure.Database;

public sealed class EventsDbContext(DbContextOptions<EventsDbContext> options):DbContext(options), IUnitOfWork
{
    internal DbSet<Event> Events { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Events);
    }
}
