namespace Clinic.Domain.Entities;

public class Appointment
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    public double Price { get; set; }
    public string Currency { get; set; } 
    public int AppointmentStatusId { get; set; }
    public int InsuranceId { get; set; }
    public int NoteId { get; set; }
}
