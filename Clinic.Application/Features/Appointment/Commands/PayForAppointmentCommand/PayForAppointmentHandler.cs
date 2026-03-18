using Clinic.Application.Mappers;
using Clinic.Application.Repositories;
using Clinic.Application.Services;
using Clinic.Domain.Entities;
using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Appointment.Commands.PayForAppointmentCommand;

public class PayForAppointmentHandler(
    IAppointmentRepository repo,
    IPayTypeQueryService service)
    : IOperationHandler<PayForAppointmentCommand, int>
{
    private readonly IAppointmentRepository _repo = repo;
    private readonly IPayTypeQueryService _service;

    public async Task<int> HandleAsync(
        PayForAppointmentCommand request, 
        CancellationToken ct = default)
    {
        // 1. Load aggregate
        var appointment = await _repo
            .GetByIdAsync(request.AppointmentId, ct)
            ?? throw new KeyNotFoundException(
                $"Appointment {request.AppointmentId} not found");

        var payTypeDto = await _service.GetPayTypeByIdAsync(request.PayTypeId, ct)
            ?? throw new KeyNotFoundException(
                $"PayType {request.PayTypeId} not found");

        var payType = payTypeDto.ToDomain(); // Map DTO to Domain Entity (or use a factory method)

        // 2. ProcessPayment - domain logic inside aggregate
        var payment = appointment.AddPayment(
                request.Amount, 
                payType//request.PayTypeId
            );

        payment.MarkAuthorized();   // e.g. payment gateway success
        payment.MarkPaid();         // money captured

        if (appointment.IsFullyPaid()) 
            appointment.MarkAsCompleted();

        // 3. Persist aggregate
        await _repo.SaveAsync(appointment, ct);
        return payment.Id;
    }
}
