using Clinic.Shared.Events;

namespace Clinic.Application.Events.NewUserCreatedEvent;

public class NewUserCreatedEvent
    : IIntegrationEvent
{
    public string UserId { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Role { get; set; } = default!;

    public string Name { get; set; } = default!;
    public string Phone { get; set; } = default!;
}
