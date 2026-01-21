namespace Clinic.Domain.Entities;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;

    public List<Booking> Bookings { get; set; } = new();
    public List<DoctorSpeciality> Specialities { get; set; } = new();
    public List<Shift> Shifts { get; set; } = new();
}
