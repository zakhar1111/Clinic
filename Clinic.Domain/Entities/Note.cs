namespace Clinic.Domain.Entities;

public class Note
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public string Text { get; set; } = string.Empty;

    public int AppointmentId { get; set; }

    public Appointment Appointment { get; set; }
}
