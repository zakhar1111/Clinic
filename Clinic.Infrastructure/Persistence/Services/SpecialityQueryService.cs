using Clinic.Application.Features.Doctor.Commands.AddDoctorSpecialityCommand;
using Clinic.Application.Services;
using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Persistence.Services;

public class SpecialityQueryService(ClinicDbContext context)
    : ISpecialityQueryService
{
    private readonly ClinicDbContext _context = context;

    public async Task<SpecialityDto> GetByIdAsync(int id, CancellationToken ct = default) =>
        await _context.Set<Speciality>()
            .Where(s => s.Id == id)
            .Select(s => new SpecialityDto(s.Id, s.Name))
            .AsNoTracking()
            .FirstOrDefaultAsync(ct);
}
