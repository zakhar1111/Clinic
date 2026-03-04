namespace Clinic.Shared.Events;

public interface IIntegrationEventHandler<TEvent>
    where TEvent : IIntegrationEvent
{
    Task HandleAsync(TEvent @event, CancellationToken ct);
}