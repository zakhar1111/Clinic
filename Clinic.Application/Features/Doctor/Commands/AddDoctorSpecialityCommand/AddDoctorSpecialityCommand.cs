using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Doctor.Commands.AddDoctorSpecialityCommand;

public class AddDoctorSpecialityCommand
    : IRequest<int>
{
    public int DoctorId { get; set; }
    public int SpecialityId { get; set; }
}
