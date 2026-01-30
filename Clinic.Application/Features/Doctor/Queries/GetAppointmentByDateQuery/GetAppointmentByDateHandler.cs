using Clinic.Application.Repositories;
using Clinic.Application.Services;
using Clinic.Domain.Entities;
using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Doctor.Queries.GetAppointmentByDateQuery;

public class GetAppointmentByDateHandler(
    IAppointmentQueryService service)
    : IOperationHandler<GetAppointmentByDateQuery, List<AppointmentSummaryDto>>
{
    private readonly IAppointmentQueryService _service = service;

    public async Task<List<AppointmentSummaryDto>?> HandleAsync(
        GetAppointmentByDateQuery request, 
        CancellationToken ct = default) =>
            await _service.GetScheduledByDoctorAndDateAsync(
                request.DoctorId,
                request.Date,
                ct);

        //        SELECT a.Id, p.Name, b.OnDate
        //FROM Appointments a
        //JOIN Bookings b ON a.BookingId = b.Id
        //WHERE b.DoctorId = @doctorId
        //AND a.Status = 'Scheduled'
}
