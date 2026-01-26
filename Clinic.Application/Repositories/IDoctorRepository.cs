using Clinic.Domain.Entities;

namespace Clinic.Application.Repositories;

public interface IDoctorRepository 
{
    Task<Doctor?> GetByIdAsync(int id, CancellationToken ct);
    Task AddAsync(Doctor doctor, CancellationToken ct);
    Task SaveAsync(Doctor doctor, CancellationToken ct);
}
