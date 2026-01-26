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

    public async Task SaveAsync(Appointment appointment, CancellationToken ct)
    {
        await _context.SaveChangesAsync(ct);
    }

    public async Task<Appointment?> GetByIdAsync(int id, CancellationToken ct) =>
        await _context
            .Set<Appointment>()
            .FindAsync(id, ct);
}
