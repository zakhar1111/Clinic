namespace Clinic.Domain.Entities;

public class DoctorSpeciality
{
    public int Id { get; set; }
    public int DoctorId { get; set; } 
    public int SpecialityId { get; set; }
}
