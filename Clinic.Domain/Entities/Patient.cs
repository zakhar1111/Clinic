namespace Clinic.Domain.Entities;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string GovId { get; set; }

    public List<Booking> Bookings { get; set; } = new();
    public void BookAppontment(DateTime time, int doctorId)
    {
        bool doctorAvailable = true;
        if(doctorAvailable)
            Bookings.Add( new Booking 
            { 
                OnDate = time,
                DoctorId = doctorId,
                PatientId = this.Id,
                BookingStatusId = 1 // Pending
            });
    }
}
