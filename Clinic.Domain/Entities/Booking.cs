namespace Clinic.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime OnDate { get; set; }
    public int DurationIn15MinSlots { get; set; }  // longevity in slots of 15 minutes for the booking
    public string Reason { get; set; } = string.Empty;
    public int BookingStatusId { get; set; }
}
