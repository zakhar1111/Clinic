using Clinic.Domain.Entities;

namespace Clinic.Application.Repositories;

public interface IPatientRepository 
{
    Task SaveAsync(Patient patient, CancellationToken ct);
    Task AddAsync(Patient patient, CancellationToken ct);
    Task<Patient?> GetByIdAsync(int id, CancellationToken ct);
} 
