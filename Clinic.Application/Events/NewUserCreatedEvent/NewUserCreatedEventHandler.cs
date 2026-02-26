using Clinic.Application.Repositories;
using Clinic.Domain.Entities;
using Clinic.Shared.Events;

namespace Clinic.Application.Events.NewUserCreatedEvent;

public class NewUserCreatedEventHandler(
    IDoctorRepository doctorRepository,
    IPatientRepository patientRepository)
    : IIntegrationEventHandler<NewUserCreatedEvent>
{
    private readonly IDoctorRepository _doctorRepository = doctorRepository;
    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task HandleAsync(
        NewUserCreatedEvent @event,
        CancellationToken ct)
    {
        // business logic here
        // create Doctor or Patient depending on role
        if (@event.Role == "Doctor")
        {
            var doctor = new Doctor
            {
                Name = @event.Email,
                Email = @event.Email
            };

            await _doctorRepository.AddAsync(doctor, ct);
        }
        else if (@event.Role == "Patient")
        {
            var patient = new Patient
            {
                Name = @event.Email,
                Email = @event.Email
            };

            await _patientRepository.AddAsync(patient, ct);
        }

    }
}
