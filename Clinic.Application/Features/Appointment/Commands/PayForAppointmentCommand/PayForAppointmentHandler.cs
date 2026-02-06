using Clinic.Application.Repositories;
using Clinic.Domain.Entities;
using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Appointment.Commands.PayForAppointmentCommand;

public class PayForAppointmentHandler(IAppointmentRepository repo)
    : IOperationHandler<PayForAppointmentCommand, int>
{
    private readonly IAppointmentRepository _repo = repo;

    public async Task<int> HandleAsync(
        PayForAppointmentCommand request, 
        CancellationToken ct = default)
    {
        // 1. Load aggregate
        var appointment = await _repo
            .GetByIdAsync(request.AppointmentId, ct)
            ?? throw new NullReferenceException(nameof(request));

        // 2. Execute business logic (inside aggregate)
        appointment.AddPayment(request.Amount, request.PayTypeId);

        // 3. Persist aggregate
        await _repo.SaveAsync(appointment, ct);
        return appointment.Id;
    }
}
