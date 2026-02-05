using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Doctor.Commands.AddDiagnosticCommand;

public class AddDiagnosticCommand
    :IRequest<int>
{
    public int AppointmentId { get; set; }
    public string TestName { get; set; }
    public string Result { get; set; }
}
