namespace Clinic.Domain.Entities;

public class Patient
{
    public int Id { get; set; }
    public string UserId { get; set; } 
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string GovId { get; set; }

    public List<Booking> Bookings { get; set; } = new();
    public Booking BookAppontment(DateTime time, int doctorId, int duration)
    {
        var newBooking = new Booking
        {
            OnDate = time,
            DoctorId = doctorId,
            PatientId = this.Id,
            DurationIn15MinSlots = duration,
            BookingStatusId = 1 // Scheduled
        };
        Bookings.Add(newBooking);
        return newBooking;
    }
}
