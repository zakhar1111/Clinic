using Clinic.Shared.Events;

namespace Clinic.Application.Events.DoctorUserCreatedEvent;

public class DoctorUserCreatedEvent 
    : IIntegrationEvent
{
    public string UserId { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Phone { get; set; } = default!;
}
