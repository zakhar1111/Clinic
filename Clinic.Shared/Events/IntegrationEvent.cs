namespace Clinic.Shared.Events;

public class IntegrationEvent
{
    public Guid Id { get; set; }

    public string Type { get; set; } //  "NewUserCreatedEvent"
    public string Payload { get; set; } // JSON string of the event
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool Processed { get; set; } = false;
}
