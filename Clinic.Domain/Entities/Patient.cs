namespace Clinic.Domain.Entities;

public class Patient
{
    public int Id { get; private set; }
    public string UserId { get; private set; } 
    public string Name { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string Phone { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string GovId { get; private set; }

    public IReadOnlyCollection<Booking> Bookings => bookings;

    private readonly List<Booking> bookings = new();
    public Booking BookAppontment(
        DateTime time,
        int doctorId,
        int duration,
        string reason)
    {
        if(time < DateTime.Now)
            throw new ArgumentException("Booking time must be in the future.");
        if(doctorId <= 0)
            throw new ArgumentException("Invalid doctorId.");
        if (duration <= 0)
            throw new ArgumentException("Duration must be positive.");

        var newBooking = Booking.Create(this.Id, doctorId, time, duration, reason);
        bookings.Add(newBooking);

        return newBooking;
    }

    private Patient() { } // for EF Core

    public static Patient Create(
        string userId,
        string name,
        DateTime dateOfBirth,
        string phone,
        string email,
        string govId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException("UserId is required.", nameof(userId));
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));
        if (dateOfBirth >= DateTime.Now)
            throw new ArgumentException("Date of birth must be in the past.", nameof(dateOfBirth));
        if (string.IsNullOrWhiteSpace(phone))
            throw new ArgumentException("Phone is required.", nameof(phone));
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.", nameof(email));
        if (string.IsNullOrWhiteSpace(govId))
            throw new ArgumentException("GovId is required.", nameof(govId));

        return new Patient
        {
            UserId = userId,
            Name = name,
            DateOfBirth = dateOfBirth,
            Phone = phone,
            Email = email,
            GovId = govId
        };
    }

}
