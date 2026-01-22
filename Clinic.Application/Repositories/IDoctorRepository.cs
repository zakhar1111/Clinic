using Clinic.Domain.Entities;

namespace Clinic.Application.Repositories;

public interface IDoctorRepository 
{
    Task<Doctor?> GetByIdAsync(int id);
    Task AddAsync(Doctor doctor);
    Task UpdateAsync(Doctor doctor);
    Task DeleteAsync(Doctor doctor);
}
