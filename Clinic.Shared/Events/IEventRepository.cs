namespace Clinic.Shared.Events;

public interface IEventRepository
{
    Task<List<IntegrationEvent>> GetUnprocessedAsync(CancellationToken ct);

    Task AddAsync(IntegrationEvent integrationEvent,CancellationToken ct);

    Task SaveChangesAsync(CancellationToken ct);
}

