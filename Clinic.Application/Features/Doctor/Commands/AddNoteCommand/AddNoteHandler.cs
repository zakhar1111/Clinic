using Clinic.Application.Repositories;
using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Doctor.Commands.AddNoteCommand;

public class AddNoteHandler(IAppointmentRepository appointmentRepository)
    : IOperationHandler<AddNoteCommand, int>
{
    private readonly IAppointmentRepository _appointmentRepository = appointmentRepository;

    public async Task<int> HandleAsync(
        AddNoteCommand request, 
        CancellationToken ct = default)
    {
        var appointment = await _appointmentRepository
            .GetByIdAsync(request.AppointmentId, ct)
            ?? throw new UnauthorizedAccessException(
                "Appointment not found for this doctor.");

        var note = appointment.AddNote(request.Content);
        await _appointmentRepository.SaveAsync(appointment, ct);
        return note.Id;
    }
}
