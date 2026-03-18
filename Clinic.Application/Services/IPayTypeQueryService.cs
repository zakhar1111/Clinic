using Clinic.Application.Features.Appointment.Commands.PayForAppointmentCommand;

namespace Clinic.Application.Services;

public interface IPayTypeQueryService
{
    Task<PayTypeDto?> GetPayTypeByIdAsync(int id, CancellationToken ct);
}
