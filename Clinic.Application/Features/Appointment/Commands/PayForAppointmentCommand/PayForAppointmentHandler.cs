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
            ?? throw new KeyNotFoundException(
                $"Appointment {request.AppointmentId} not found");

        // 2. ProcessPayment - domain logic inside aggregate
        var payment = appointment.AddPayment(
                request.Amount, 
                request.PayTypeId
            );

        payment.MarkAuthorized();   // e.g. payment gateway success
        payment.MarkPaid();         // money captured

        if (appointment.IsFullyPaid()) 
            appointment.MarkAsCompleted();

        // 3. Persist aggregate
        await _repo.SaveAsync(appointment, ct);
        return appointment.Id;
    }
}
