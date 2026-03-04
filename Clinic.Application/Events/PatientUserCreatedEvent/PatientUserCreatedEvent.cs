using Clinic.Shared.Events;

namespace Clinic.Application.Events.PatientUserCreatedEvent;

public class PatientUserCreatedEvent 
    : IIntegrationEvent
{
    public string UserId { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string GovId { get; set; } = default!;
    public DateTime DateOfBirth { get; set; } = default!;
}
