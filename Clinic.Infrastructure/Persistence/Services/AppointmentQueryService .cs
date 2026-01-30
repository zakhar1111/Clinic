using Clinic.Application.Features.Doctor.Queries.GetAppointmentByDateQuery;
using Clinic.Application.Services;
using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Persistence.Services;

public class AppointmentQueryService(ClinicDbContext context)
    : IAppointmentQueryService
{
    private readonly ClinicDbContext _context = context;

    public async Task<List<AppointmentSummaryDto>> GetScheduledByDoctorAndDateAsync(
        int doctorId,
        DateTime date,
        CancellationToken ct)
    {
        return await _context.Set<Appointment>()
            .Join(
                _context.Set<Booking>(),
                a => a.BookingId,
                b => b.Id,
                (a, b) => new { a, b }
            )
            .Join(
                _context.Set<Patient>(),
                ab => ab.b.PatientId,
                p => p.Id,
                (ab, p) => new { ab.a, ab.b, p }
            )
            .Where(a =>
                a.b.DoctorId == doctorId &&
                a.b.OnDate.Date == date.Date &&
                a.a.AppointmentStatus.Name == "Scheduled")
            .Select(x => new AppointmentSummaryDto
            {
                AppointmentId = x.a.Id,
                Date = x.b.OnDate,
                PatientName = x.p.Name,
                Status = x.a.AppointmentStatus.Name
            })
            .AsNoTracking()
            .ToListAsync(ct);
    }
}

