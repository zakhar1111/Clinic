namespace Clinic.Shared.Events;

public interface IIntegrationEventDispatcher
{
    Task DispatchAsync(string eventType,string payload,CancellationToken ct);
}
