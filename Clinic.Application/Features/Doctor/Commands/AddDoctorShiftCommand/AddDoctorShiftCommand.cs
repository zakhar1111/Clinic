using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Doctor.Commands.AddDoctorShiftCommand;

public class AddDoctorShiftCommand
    : IRequest<int>
{
    public int DoctorId { get; set; }
    public TimeSpan StartTime { get; set; }
    public int Slot15Min { get; set; }
}
