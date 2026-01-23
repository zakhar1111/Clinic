namespace Clinic.Domain.Entities;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string GovId { get; set; }

    public List<Booking> Bookings { get; set; } = new();

    public void Update(Patient patient)
    {
        throw new NotImplementedException();
    }
}
