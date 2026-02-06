using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Patient.Commands.AttachInsuranceCommand;

public class AttachInsuranceCommand
    : IRequest<int>
{
    public int AppointmentId { get; set; }
    public string Provider { get; set; }
    public int Coverage { get; set; }
}
