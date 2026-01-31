namespace Clinic.Domain.Entities;

// Shift
// - defines capacity, not current state.
// - stays immutable during the day.
public class Shift
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public int Slot15Min { get; set; } // capasity of the shift in 15 min slots
    public TimeSpan StartTime { get; set; }
    public DateOnly Day { get; set; }
}
