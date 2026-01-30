using Clinic.Application.Repositories;
using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Doctor.Commands.AddDoctorShiftCommand;

internal class AddDoctorShiftHandler(IDoctorRepository doctorRepository)
    : IOperationHandler<AddDoctorShiftCommand, int>
{
    private readonly IDoctorRepository _doctorRepository = doctorRepository;

    public async Task<int> HandleAsync(AddDoctorShiftCommand command, CancellationToken ct = default)
    {
        var doctor = await _doctorRepository.GetByIdAsync(command.DoctorId, ct)
            ?? throw new KeyNotFoundException("Doctor not found");

        doctor.AddShift(command.StartTime, command.Slot15Min);

        await _doctorRepository.SaveAsync(doctor,ct);
        return doctor.Id;
    }
}
