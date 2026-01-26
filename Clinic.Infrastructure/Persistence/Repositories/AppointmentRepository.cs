using Clinic.Application.Repositories;
using Clinic.Domain.Entities;

namespace Clinic.Infrastructure.Persistence.Repositories;

public class AppointmentRepository(ClinicDbContext context)
    : IAppointmentRepository
{
    private readonly ClinicDbContext _context = context;

    public async Task AddAsync(Appointment appointment, CancellationToken ct)
    {
        if(appointment == null)
            throw new ArgumentNullException(nameof(appointment));

        await _context.Set<Appointment>().AddAsync(appointment, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Appointment appointment, CancellationToken ct)
    {
        var toDelete = await _context
            .Set<Appointment>()
            .FindAsync(appointment.Id,ct) ??
            throw new KeyNotFoundException(nameof(appointment));

        _context.Remove(toDelete);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<Appointment?> GetByIdAsync(int id, CancellationToken ct) =>
        await _context
            .Set<Appointment>()
            .FindAsync(id, ct);

    public async Task UpdateAsync(Appointment appointment, CancellationToken ct)
    {
        var toUpdate = await _context
            .Set<Appointment>()
            .FindAsync(appointment.Id, ct) ??
            throw new KeyNotFoundException(nameof(appointment));

        toUpdate.Update(appointment);
        await _context.SaveChangesAsync(ct);
    }
}
