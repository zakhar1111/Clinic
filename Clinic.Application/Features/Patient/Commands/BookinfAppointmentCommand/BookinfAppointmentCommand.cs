using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Patient.Commands.BookinfAppointmentCommand;

public class BookinfAppointmentCommand
    : IRequest<int>
{
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime OnDate { get; set; }
}
