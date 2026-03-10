namespace Clinic.Domain.Entities;

public class AppointmentStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public enum AppointmentStatusEnum
{
    InProgress = 1,
    Scheduled  = 2,
    Cancelled  = 3,
    Completed  = 4
}

