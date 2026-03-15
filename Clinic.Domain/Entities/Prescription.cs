namespace Clinic.Domain.Entities;

public class Prescription
{
    public int Id { get; private set; }
    public string Medicine { get; private set; }
    public string Dosage { get; private set; }
    public string Frequency { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public int AppointmentId { get; private set; }

    public Appointment Appointment { get; private set; }

    private Prescription() { } // for EF Core

    public static Prescription Create(string medicine,
        string dosage,
        string frequency,
        Appointment appointment)
    {
        if (string.IsNullOrWhiteSpace(medicine))
            throw new ArgumentException("Medicine name cannot be empty.");
        if (string.IsNullOrWhiteSpace(dosage))
            throw new ArgumentException("Dosage information cannot be empty.");
        if (string.IsNullOrWhiteSpace(frequency))
            throw new ArgumentException("Frequency information cannot be empty.");
        if (appointment is null)
            throw new ArgumentException("Invalid appointment.");

        return new Prescription
        {
            Medicine = medicine,
            Dosage = dosage,
            Frequency = frequency,
            CreatedAt = DateTime.UtcNow,
            AppointmentId = appointment.Id,
            Appointment = appointment
        };
    }
}
