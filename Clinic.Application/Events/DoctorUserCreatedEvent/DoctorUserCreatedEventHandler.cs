using Clinic.Application.Repositories;
using Clinic.Domain.Entities;
using Clinic.Shared.Events;

namespace Clinic.Application.Events.DoctorUserCreatedEvent;

public class DoctorUserCreatedEventHandler(
    IDoctorRepository doctorRepository)
    : IIntegrationEventHandler<DoctorUserCreatedEvent>
{
    private readonly IDoctorRepository _doctorRepository = doctorRepository;

    public async Task HandleAsync(
        DoctorUserCreatedEvent @event,
        CancellationToken ct)
    {
        var doctor = Doctor.Create(
            userId: @event.UserId,
            name: @event.Name,
            phone: @event.Phone,
            email: @event.Email,
            bio: ""
        );

        await _doctorRepository.AddAsync(doctor, ct);
        await _doctorRepository.SaveAsync(doctor, ct);
    }
}

