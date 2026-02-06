using Clinic.Application.Repositories;
using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Doctor.Commands.AddDiagnosticCommand;

public class AddDiagnosticHandler(IAppointmentRepository appointmentRepository)
    : IOperationHandler<AddDiagnosticCommand, int>
{
    private readonly IAppointmentRepository _appointmentRepository = appointmentRepository;

    public async Task<int> HandleAsync(AddDiagnosticCommand request, CancellationToken ct = default)
    {
        var appointment = await _appointmentRepository
            .GetByIdAsync(request.AppointmentId, ct)
            ?? throw new InvalidOperationException(
                "Appointment not found for this doctor.");

        appointment.Start(); // safe - domain rule enforced inside
        var diagnostic = appointment.AddDiagnostic(request.TestName, request.Result);
        
        await _appointmentRepository.SaveAsync(appointment, ct);

        return diagnostic.Id;
    }
}
