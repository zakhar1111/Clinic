using Clinic.Application.Repositories;
using Clinic.Application.Services;
using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Patient.Commands.BookinfAppointmentCommand;

public class BookingAppointmentHandler(
    IPatientRepository patientRepository,
    IDoctorAvailabilityService doctorAvailabilityService)
    : IOperationHandler<BookinfAppointmentCommand, int>
{
    private readonly IPatientRepository _patientRepository = patientRepository;
    private readonly IDoctorAvailabilityService _doctorAvailabilityService = doctorAvailabilityService;

    public async Task<int> HandleAsync(BookinfAppointmentCommand request, CancellationToken ct = default)
    {
        var patient = await _patientRepository
            .GetByIdAsync(request.PatientId, ct)
            ?? throw new KeyNotFoundException("Patient not found");

        await _doctorAvailabilityService
            .EnsureAvailabilityAsync(
                request.DoctorId,
                request.OnDate,
                request.DurationInSlots,
                ct
            );


        var newBooking = patient.BookAppontment(
            request.OnDate, 
            request.DoctorId, 
            request.DurationInSlots
            );

        await _patientRepository.SaveAsync(patient, ct);
        return newBooking.Id;
    }
}
