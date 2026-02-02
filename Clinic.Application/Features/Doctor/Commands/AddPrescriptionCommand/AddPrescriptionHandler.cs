using Clinic.Application.Repositories;
using Clinic.Domain.Entities;
using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Doctor.Commands.AddPrescriptionCommand;

public class AddPrescriptionHandler(
    IAppointmentRepository appointmentRepository)
    : IOperationHandler<AddPrescriptionCommand, int>
{
    private readonly IAppointmentRepository _appointmentRepository = appointmentRepository;

    public async Task<int> HandleAsync(AddPrescriptionCommand request, CancellationToken ct = default)
    {
        var appointment = await _appointmentRepository
            .GetByIdAsync(request.AppointmentId, ct)
            ?? throw new UnauthorizedAccessException(
                "Appointment not found for this doctor.");

       var prescription = appointment.AddPrescription(
            request.Medication,
            request.Dosage,
            request.Instructions);

        await _appointmentRepository.SaveAsync(appointment,ct);

        return prescription.Id;
    }
}
