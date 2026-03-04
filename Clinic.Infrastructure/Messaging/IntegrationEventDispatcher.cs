using Clinic.Application.Events.NewUserCreatedEvent;
using Clinic.Shared.Events;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace Clinic.Infrastructure.Messaging;

public class IntegrationEventDispatcher(
        IServiceProvider provider,
        IEventRepository repository)
{
    private readonly IServiceProvider _provider = provider;
    private readonly IEventRepository _repository = repository;

    public async Task DispatchAsync(CancellationToken ct)
    {
        Console.WriteLine("Dispatching integration events...");
        var events = await _repository.GetUnprocessedAsync(ct);

        foreach (var integrationEvent in events)
        {
            var eventType = Type.GetType(integrationEvent.Type);

            if (eventType is null)
                continue;

            var @event = JsonSerializer.Deserialize(
                integrationEvent.Payload,
                eventType
            );

            var handlerType = typeof(IIntegrationEventHandler<>)
                .MakeGenericType(eventType);

            var handler = _provider.GetService(handlerType);

            if (handler is null)
                continue;

            var method = handlerType.GetMethod("HandleAsync");

            await (Task)method!.Invoke(handler, new[] { @event!, ct });

            integrationEvent.Processed = true;
        }

        await _repository.SaveChangesAsync(ct);
    }
}
