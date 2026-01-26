
namespace Clinic.Domain.Entities;

public class Appointment
{
    public int Id { get; set; }

    public decimal Price { get; set; }
    public string Currency { get; set; }

    public int BookingId { get; set; }
    public int AppointmentStatusId { get; set; }
    public int? InsuranceId { get; set; }

    public AppointmentStatus AppointmentStatus { get; set; }
    public Booking Booking { get; set; }
    public Insurance? Insurance { get; set; }
    public List<Note> Notes { get; set; } = new();
    public List<Prescription> Prescriptions { get; set; } = new();
    public List<Diagnostic> Diagnostics { get; set; } = new();
    public List<Payment> Payments { get; set; } = new();

}
