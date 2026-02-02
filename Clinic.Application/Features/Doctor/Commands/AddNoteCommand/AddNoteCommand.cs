using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Doctor.Commands.AddNoteCommand;

public class AddNoteCommand
    :IRequest<int>
{
    public int AppointmentId { get; set; }
    public string Content { get; set; }
}
