using Clinic.Application.Features.Appointment.Commands.PayForAppointmentCommand;
using Clinic.Application.Services;
using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Persistence.Services;

public class PayTypeQueryService(ClinicDbContext context)
    : IPayTypeQueryService
{
    private readonly ClinicDbContext _context = context;
    public async Task<PayTypeDto?> GetPayTypeByIdAsync(int id, CancellationToken ct)
    => await _context.Set<PayType>()
        .Where(p => p.Id == id)
        .Select(p => new PayTypeDto(p.Id,p.Name ))
        .AsNoTracking()
        .FirstOrDefaultAsync(ct);
}
