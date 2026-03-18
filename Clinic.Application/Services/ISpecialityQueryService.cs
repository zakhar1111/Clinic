using Clinic.Application.Features.Doctor.Commands.AddDoctorSpecialityCommand;

namespace Clinic.Application.Services;

public interface ISpecialityQueryService
{
    Task<SpecialityDto> GetByIdAsync(int id, CancellationToken ct = default);
}
