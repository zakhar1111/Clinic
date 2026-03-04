
namespace Clinic.Domain.Entities;

public class Doctor
{
    public int Id { get; set; }
    public string UserId { get; set; } 
    public string Name { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;

    public List<Booking> Bookings { get; set; } = new();
    public List<DoctorSpeciality> Specialities { get; set; } = new();
    public List<Shift> Shifts { get; set; } = new();

    public void AddSpeciality(int specialityId)
    {
        if (Specialities.Any(s => s.SpecialityId == specialityId))
            throw new InvalidOperationException("Speciality already exists");

        Specialities.Add(new DoctorSpeciality
        {
            DoctorId = this.Id,
            SpecialityId = specialityId
        });
    }

    public void AddShift(TimeSpan start, int slot)
    {
        if (Shifts.Any(s => s.StartTime == start))
            throw new InvalidOperationException("Shift already exists");

        Shifts.Add(new Shift
        {
            DoctorId = this.Id,
            StartTime = start,
            Slot15Min = slot
        });
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
