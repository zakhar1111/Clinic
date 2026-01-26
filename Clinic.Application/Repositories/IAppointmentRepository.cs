using Clinic.Domain.Entities;

namespace Clinic.Application.Repositories;

public interface IAppointmentRepository 
{
    Task<Appointment?> GetByIdAsync(int id, CancellationToken ct);
    Task AddAsync(Appointment appointment, CancellationToken ct);
    Task UpdateAsync(Appointment appointment, CancellationToken ct);
    Task DeleteAsync(Appointment appointment, CancellationToken ct);
}