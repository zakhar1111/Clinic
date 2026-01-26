using Clinic.Application.Repositories;
using Clinic.Domain.Entities;

namespace Clinic.Infrastructure.Persistence.Repositories;

public class DoctorRepository(ClinicDbContext context)
    : IDoctorRepository
{
    private readonly ClinicDbContext _context = context;

    public async Task AddAsync(Doctor doctor, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(doctor);

        await _context.Set<Doctor>().AddAsync(doctor, ct);
        await _context.SaveChangesAsync(ct);
    }



    public async Task<Doctor?> GetByIdAsync(int id, CancellationToken ct) =>
        await _context
            .Set<Doctor>()
            .FindAsync(id, ct);

    public async Task SaveAsync(Doctor doctor, CancellationToken ct) =>
        await _context.SaveChangesAsync(ct);
}
