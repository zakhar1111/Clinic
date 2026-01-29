using Clinic.Application.Repositories;
using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Clinic.Infrastructure.Persistence.Repositories;


public class PatientRepository(ClinicDbContext context)
    : IPatientRepository
{
    private readonly ClinicDbContext _context = context;
    public async Task SaveAsync(Patient patient, CancellationToken ct) =>
        await _context.SaveChangesAsync(ct);
    public async Task AddAsync(Patient patient, CancellationToken ct) 
    {
        ArgumentNullException.ThrowIfNull(patient);

        await _context.Set<Patient>().AddAsync(patient, ct);
    }
    public async Task<Patient?> GetByIdAsync(int id, CancellationToken ct) =>
        await _context
            .Set<Patient>()
            .Include(p => p.Bookings)
            .FirstOrDefaultAsync(p => p.Id == id, ct);
}
