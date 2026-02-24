using Clinic.Shared.Events;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Shared.Infrastructure;

public class EventRepository(SharedDbContext context)
    : IEventRepository
{
    private readonly SharedDbContext _context = context;

    public async Task<List<IntegrationEvent>> 
        GetUnprocessedAsync(CancellationToken ct)
        => await _context.Set<IntegrationEvent>()
                .Where(e => !e.Processed)
                .OrderBy(e => e.CreatedAt)
                .ToListAsync(ct);

    public async Task AddAsync(
        IntegrationEvent integrationEvent,
        CancellationToken ct)
        => await _context.AddAsync(integrationEvent, ct);

    public async Task SaveChangesAsync(CancellationToken ct)
        => await _context.SaveChangesAsync(ct);
}
