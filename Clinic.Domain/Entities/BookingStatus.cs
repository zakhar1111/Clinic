namespace Clinic.Domain.Entities;

public class BookingStatus
{
    public int Id { get; set; }
    public string Name { get; set; } 
}

public enum BookingStatusEnum
{
    Scheduled = 1,
    Confirmed = 2,
    Cancelled = 3,
    Completed = 4
}
