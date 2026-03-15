namespace Clinic.Domain.Entities;

public class DoctorSpeciality
{
    public int Id { get; private set; }
    public int DoctorId { get; private set; } 
    public int SpecialityId { get; private set; }

    private DoctorSpeciality() { }

    public static DoctorSpeciality Create(int doctorId, int specialityId)
    {
        if (doctorId <= 0)
            throw new ArgumentException("Id must be a positive integer.");
        if (specialityId <= 0)
            throw new ArgumentException("Id must be a positive integer.");

        return new DoctorSpeciality
        {
            DoctorId = doctorId,
            SpecialityId = specialityId
        };
    }
}
