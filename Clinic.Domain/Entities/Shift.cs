namespace Clinic.Domain.Entities;

public class Shift
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public int Slot15Min { get; set; }
    public TimeSpan StartTime { get; set; }
}
