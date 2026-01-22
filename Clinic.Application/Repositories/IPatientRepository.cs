using Clinic.Domain.Entities;

namespace Clinic.Application.Repositories;

public interface IPatientRepository 
{
    Task UpdateAsync(Patient patient);
    Task DeleteAsync(Patient patient);
    Task AddAsync(Patient patient);
    Task<Patient?> GetByIdAsync(int id);
} 
