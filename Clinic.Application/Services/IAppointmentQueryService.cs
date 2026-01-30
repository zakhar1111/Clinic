using Clinic.Application.Features.Doctor.Queries.GetAppointmentByDateQuery;

namespace Clinic.Application.Services;

public interface IAppointmentQueryService
{
    Task<List<AppointmentSummaryDto>> GetScheduledByDoctorAndDateAsync(
        int doctorId,
        DateTime date,
        CancellationToken ct);
}
