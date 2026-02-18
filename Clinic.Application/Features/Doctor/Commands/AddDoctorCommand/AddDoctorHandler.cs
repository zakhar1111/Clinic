using Clinic.Application.Repositories;
using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Doctor.Commands.AddDoctorCommand;

public class AddDoctorHandler(IDoctorRepository doctorRepository)
    : IOperationHandler<AddDoctorCommand, int>
{
    private readonly IDoctorRepository _doctorRepository = doctorRepository;

    public async Task<int> HandleAsync(AddDoctorCommand request, CancellationToken ct = default)
    {
        var doctor = Clinic.Domain.Entities.Doctor.Create(
            request.UserId,
            request.Name,
            request.Phone,
            request.Email,
            request.Bio
        );
        await _doctorRepository.AddAsync(doctor, ct);

        await _doctorRepository.SaveAsync(doctor, ct);

        return doctor.Id;
    }
}