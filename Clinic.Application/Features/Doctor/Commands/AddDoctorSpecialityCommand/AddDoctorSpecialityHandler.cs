using Clinic.Application.Repositories;
using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Doctor.Commands.AddDoctorSpecialityCommand;

public class AddDoctorSpecialityHandler(IDoctorRepository doctorRepository)
    : IOperationHandler<AddDoctorSpecialityCommand, int>
{
    private readonly IDoctorRepository _doctorRepository = doctorRepository;

    public async Task<int> HandleAsync(
        AddDoctorSpecialityCommand request, 
        CancellationToken ct = default)
    {
        var doctor = await _doctorRepository
            .GetByIdAsync(request.DoctorId, ct)
            ?? throw new KeyNotFoundException("Doctor not found");

        doctor.AddSpeciality(request.SpecialityId);

        await _doctorRepository.SaveAsync(doctor, ct);
        return doctor.Id;
    }
}
