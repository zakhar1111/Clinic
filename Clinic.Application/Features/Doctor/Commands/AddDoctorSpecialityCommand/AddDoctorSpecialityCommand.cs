using Clinic.Domain.Entities;
using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Doctor.Commands.AddDoctorSpecialityCommand;

public class AddDoctorSpecialityCommand
    : IRequest<int>
{
    public int DoctorId { get; set; }

    public Speciality Speciality { get; set; } = null!;
}
