using Clinic.Application.Features.Doctor.Commands.AddDoctorSpecialityCommand;
using Clinic.Domain.Entities;

namespace Clinic.Application.Mappers;

public static class SpecialityMapper
{
    public static SpecialityDto ToDto(this Domain.Entities.Speciality domain)
    {
        if (domain is null)
            throw new ArgumentNullException(nameof(domain));
        return new SpecialityDto(domain.Id, domain.Name);
    }
    public static Speciality ToDomain(this SpecialityDto dto)
    {
        if (dto is null)
            throw new ArgumentNullException(nameof(dto));
        return Speciality.Seed(dto.Id, dto.Name);
    }
}
