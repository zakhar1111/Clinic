using Clinic.Application.Repositories;
using Clinic.Domain.Entities;

namespace Clinic.Infrastructure.Persistence.Repositories;


public class PatientRepository(ClinicDbContext context)
    : IPatientRepository
{
    private readonly ClinicDbContext _context = context;
    public async Task UpdateAsync(Patient patient, CancellationToken ct)
    {
        var existingPatient = await _context
            .Set<Patient>()
            .FindAsync(new object?[] { patient.Id}, ct) ??
            throw new KeyNotFoundException("Patient not found.");

        existingPatient.Update(patient);
        await _context.SaveChangesAsync(ct);
    }
    public async Task DeleteAsync(int id, CancellationToken ct) 
    { 
        var toDelete = await _context
            .Set<Patient>()
            .FindAsync(id, ct) ??
            throw new KeyNotFoundException("Patient not found.");
        _context.Remove(toDelete);
        await _context.SaveChangesAsync(ct);
    }
    public async Task AddAsync(Patient patient, CancellationToken ct) 
    {
        if (patient == null)
        {
            throw new ArgumentNullException(nameof(patient));
        }

        await _context.Set<Patient>().AddAsync(patient, ct);
        await _context.SaveChangesAsync(ct);
    }
    public async Task<Patient?> GetByIdAsync(int id, CancellationToken ct) =>
        await _context
            .Set<Patient>()
            .FindAsync(new object?[] { id }, ct);
}
