namespace Clinic.Domain.Entities;

// Shift
// - defines capacity, not current state.
// - stays immutable during the day.
public class Shift
{
    public int Id { get; private set; }
    public int DoctorId { get; private set; }
    public int Slot15Min { get; private set; } // capasity of the shift in 15 min slots
    public TimeSpan StartTime { get; private set; }
    public DateOnly Day { get; private set; }

    private Shift() { } // EF

    public static Shift Create(
        int doctorId, 
        TimeSpan startTime, 
        int slot15Min, 
        DateOnly day
        )
    {
        if (doctorId <= 0)
            throw new ArgumentException("DoctorId must be a positive integer.", nameof(doctorId));
        if (slot15Min <= 0)
            throw new ArgumentException("Slot15Min must be a positive integer.", nameof(slot15Min));
        if (startTime < TimeSpan.Zero || startTime >= TimeSpan.FromDays(1))
            throw new ArgumentOutOfRangeException(nameof(startTime), "StartTime must be between 00:00 and 23:59.");
        return new Shift
        {
            DoctorId = doctorId,
            StartTime = startTime,
            Slot15Min = slot15Min,
            Day = day
        };
    }
}
