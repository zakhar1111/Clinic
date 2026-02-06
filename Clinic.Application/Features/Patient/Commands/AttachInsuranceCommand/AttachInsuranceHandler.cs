using Clinic.Application.Repositories;
using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Patient.Commands.AttachInsuranceCommand;

public class AttachInsuranceHandler(IAppointmentRepository appointmentRepository)
    : IOperationHandler<AttachInsuranceCommand, int>
{
    private readonly IAppointmentRepository _appointmentRepository = appointmentRepository;

    public async Task<int> HandleAsync(AttachInsuranceCommand request, CancellationToken ct = default)
    {
        var appointment =  await _appointmentRepository
            .GetByIdAsync(request.AppointmentId, ct)
            ?? throw new InvalidOperationException("Appointment not found.");

        var newInsurance = appointment.ApplyInsurance(
            request.Provider,
            request.Coverage
            );

        await _appointmentRepository.SaveAsync(appointment, ct);
        return newInsurance.Id;
    }
}