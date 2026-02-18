using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Doctor.Commands.AddDoctorCommand;

public class AddDoctorCommand
    : IRequest<int>
{
    public string Name { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Bio { get; set; } = default!;
}
