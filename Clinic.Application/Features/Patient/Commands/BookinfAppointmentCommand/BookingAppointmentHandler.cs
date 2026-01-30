using Clinic.Application.Repositories;
using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Patient.Commands.BookinfAppointmentCommand;

public class BookingAppointmentHandler(IPatientRepository patientRepository)
    : IOperationHandler<BookinfAppointmentCommand, int>
{
    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task<int> HandleAsync(BookinfAppointmentCommand request, CancellationToken ct = default)
    {
        var patient = await _patientRepository
            .GetByIdAsync(request.PatientId, ct)
            ?? throw new KeyNotFoundException("Patient not found");

        patient.BookAppontment(request.OnDate, request.DoctorId);

        await _patientRepository.SaveAsync(patient, ct);
        return patient.Id;
    }
}
