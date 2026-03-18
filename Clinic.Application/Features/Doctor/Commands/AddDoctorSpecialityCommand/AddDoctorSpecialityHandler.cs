using Clinic.Application.Repositories;
using Clinic.Application.Services;
using Clinic.Shared.Messaging;
using Clinic.Application.Mappers;

namespace Clinic.Application.Features.Doctor.Commands.AddDoctorSpecialityCommand;

public class AddDoctorSpecialityHandler(
    IDoctorRepository doctorRepository,
    ISpecialityQueryService service)
    : IOperationHandler<AddDoctorSpecialityCommand, int>
{
    private readonly IDoctorRepository _doctorRepository = doctorRepository;
    private readonly ISpecialityQueryService _service = service;
    public async Task<int> HandleAsync(
        AddDoctorSpecialityCommand request, 
        CancellationToken ct = default)
    {
        var doctor = await _doctorRepository
            .GetByIdAsync(request.DoctorId, ct)
            ?? throw new KeyNotFoundException("Doctor not found");

        SpecialityDto specialityDto = await _service.GetByIdAsync(request.SpecialityId, ct)
            ?? throw new KeyNotFoundException("Speciality not found");

        var speciality = specialityDto.ToDomain();

        doctor.AddSpeciality(speciality);

        await _doctorRepository.SaveAsync(doctor, ct);
        return doctor.Id;
    }
}
