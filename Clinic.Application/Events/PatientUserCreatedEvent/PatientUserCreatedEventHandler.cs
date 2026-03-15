using Clinic.Application.Repositories;
using Clinic.Domain.Entities;
using Clinic.Shared.Events;

namespace Clinic.Application.Events.PatientUserCreatedEvent;

public class PatientUserCreatedEventHandler(
    IPatientRepository patientRepository)
    : IIntegrationEventHandler<PatientUserCreatedEvent>
{
    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task HandleAsync(
        PatientUserCreatedEvent @event,
        CancellationToken ct)
    {
        var patient = Patient.Create(
            @event.UserId,
            @event.Name,
            @event.DateOfBirth,
            @event.Phone,
            @event.Email,
            @event.GovId
        );

        await _patientRepository.AddAsync(patient, ct);
        await _patientRepository.SaveAsync(patient, ct);
    }
}

