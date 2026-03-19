namespace Clinic.Domain.Entities;

public class Note
{
    public int Id { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public string Text { get; private set; } 

    public int AppointmentId { get; private set; }

    public Appointment Appointment { get; private set; }

    private Note() { } // for EF Core

    public static Note Create(string text, Appointment appointment)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Note text cannot be empty.");
        if (appointment is null)
            throw new ArgumentException("Invalid appointment.");

        return new Note
        {
            Text = text,
            CreatedAt = DateTime.UtcNow,
            AppointmentId = appointment.Id,
            Appointment = appointment
        };
    }
}
