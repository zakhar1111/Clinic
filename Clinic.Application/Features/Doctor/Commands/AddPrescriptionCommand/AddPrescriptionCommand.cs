using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Doctor.Commands.AddPrescriptionCommand;

public class AddPrescriptionCommand
    : IRequest<int>
{
    public int DoctorId { get; set; }
    public int AppointmentId { get; set; }
    public string Medication { get; set; }
    public string Dosage { get; set; }
    public string Instructions { get; set; }
}
