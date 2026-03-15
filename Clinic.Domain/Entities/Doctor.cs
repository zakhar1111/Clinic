
namespace Clinic.Domain.Entities;

public class Doctor
{
    public int Id { get; private set; }
    public string UserId { get; private set; } 
    public string Name { get; private set; }
    public string Phone { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Bio { get; private set; } = string.Empty;

    public IReadOnlyCollection<Booking> Bookings => bookings;
    public IReadOnlyCollection<DoctorSpeciality> Specialities => doctorSpecialities;
    public IReadOnlyCollection<Shift> Shifts => shifts;


    private readonly List<Booking> bookings = new();
    private readonly List<DoctorSpeciality> doctorSpecialities = new();
    private readonly List<Shift> shifts = new();

    public void AddSpeciality(Speciality speciality)//(int specialityId)
    {
        if (Specialities.Any(s =>
            s.SpecialityId == speciality.Id &&
            s.DoctorId == this.Id)
            )
        {
            throw new InvalidOperationException("Speciality already exists");
        }

        var newDoctorSpeciality = DoctorSpeciality.Create(this.Id, speciality.Id);
        doctorSpecialities.Add(newDoctorSpeciality);
    }

    public void AddShift(TimeSpan start, int slot, DateOnly day)
    {
        if (Shifts.Any(s => s.StartTime == start))
            throw new InvalidOperationException("Shift already exists");

        var newShift = Shift.Create(this.Id, start, slot, day);

        shifts.Add(newShift);
    }

    public static Doctor Create(
        string userId,
        string name,
        string phone,
        string email,
        string bio)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required", nameof(name));
        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException("UserId is required", nameof(userId));

        return new Doctor
        {
            Name = name,
            Phone = phone ?? string.Empty,
            Email = email ?? string.Empty,
            Bio = bio ?? string.Empty,
            UserId = userId
        };
    }
}
