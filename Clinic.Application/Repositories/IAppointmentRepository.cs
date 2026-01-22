using Clinic.Domain.Entities;

namespace Clinic.Application.Repositories;

public interface IAppointmentRepository 
{
    Task<Appointment?> GetByIdAsync(int id);
    Task AddAsync(Appointment appointment);
    Task UpdateAsync(Appointment appointment);
    Task DeleteAsync(Appointment appointment);
}