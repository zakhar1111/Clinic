namespace Clinic.Domain.Entities;

public class AppointmentStatus
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    private AppointmentStatus() { }
    public static AppointmentStatus Seed(int id, string name)
        => new AppointmentStatus { Id = id, Name = name };
}
public enum AppointmentStatusEnum
{
    InProgress = 1,
    Scheduled  = 2,
    Cancelled  = 3,
    Completed  = 4
}

