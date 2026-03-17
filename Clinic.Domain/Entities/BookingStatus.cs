namespace Clinic.Domain.Entities;

public class BookingStatus
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    private BookingStatus() { }
    public static BookingStatus Seed(int id, string name)
        => new BookingStatus { Id = id, Name = name };
}

public enum BookingStatusEnum
{
    Scheduled = 1,
    Confirmed = 2,
    Cancelled = 3,
    Completed = 4
}
