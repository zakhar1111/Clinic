using Clinic.Infrastructure.Messaging;

public class IntegrationEventBackgroundService(
    IServiceProvider provider)
    : BackgroundService
{
    private readonly IServiceProvider _provider = provider;

    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _provider.CreateScope();

            var dispatcher = scope.ServiceProvider
                .GetRequiredService<IntegrationEventDispatcher>();

            await dispatcher.DispatchAsync(stoppingToken);

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }
}