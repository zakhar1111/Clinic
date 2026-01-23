using Clinic.Domain.Entities;

namespace Clinic.Application.Repositories;

public interface IPatientRepository 
{
    Task UpdateAsync(Patient patient, CancellationToken ct);
    Task DeleteAsync(int id, CancellationToken ct);
    Task AddAsync(Patient patient, CancellationToken ct);
    Task<Patient?> GetByIdAsync(int id, CancellationToken ct);
} 
